using PAWProject.Entities;
using System.Data.SQLite;
using System.Net.WebSockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml.Linq;

namespace PAWProject
{
    public partial class MainForm : Form
    {
        private const string ConnectionString = "Data Source=db.sqlite";
        private void LoadStocks()
        {
            string query = "SELECT * FROM Stocks";
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                var command = new SQLiteCommand(query, connection);
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        long id = (long)reader["ID"];
                        string name = (string)reader["Name"];
                        string token = (string)reader["Token"];
                        Stock.CTR = (int)id - 1;
                        Stock stock = new Stock(name, token);
                    }
                }
            }
        }
        private void LoadPortfolios()
        {
            string query = "SELECT * FROM Portfolios";
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                var command = new SQLiteCommand(query, connection);
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        long id = (long)reader["ID"];
                        string name = (string)reader["Name"];
                        Portfolio.CTR = (int)id - 1;
                        Portfolio portfolio = new Portfolio(name);
                    }
                }
            }
        }
        private void LoadTransactions()
        {
            string query = "SELECT * FROM Transactions";
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                var command = new SQLiteCommand(query, connection);
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        long id = (long)reader["ID"];
                        long stockId = (long)reader["Stock_ID"];
                        DateTime date = DateTime.Parse((string)reader["Date"]);
                        double price = (double)reader["Price"];
                        long quantity = (long)reader["Quantity"];
                        string type = (string)reader["Type"];
                        long portfolioId = (long)reader["Portfolio_ID"];
                        TransactionType enumType = TransactionType.BUY;
                        switch (type)
                        {
                            case "BUY":
                                enumType = TransactionType.BUY;
                                break;
                            case "SELL":
                                enumType = TransactionType.SELL;
                                break;
                        }
                        Portfolio portfolio = Portfolio.SavedItems.Find(p => p.Id == portfolioId) as Portfolio;
                        Transaction.CTR = (int)id - 1;
                        Transaction transaction = new Transaction(enumType, (int)stockId, date, (decimal)price, (int)quantity, portfolio);
                        portfolio.addTransaction(transaction.Id);
                    }
                }
            }
        }
        private void LoadClients()
        {
            string query = "SELECT * FROM Clients";
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                var command = new SQLiteCommand(query, connection);
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        long portfolioId = 0;
                        long id = (long)reader["ID"];
                        string firstName = (string)reader["First_name"];
                        string lastName = (string)reader["Last_name"];
                        if (!reader.IsDBNull(1))
                            portfolioId = (long)reader["Portfolio_ID"];
                        DateTime birthDate = DateTime.Parse((string)reader["Birth_date"]);
                        Client.CTR = (int)id - 1;
                        Client client = new Client(firstName, lastName, birthDate);
                        if (portfolioId != 0)
                            client.PortfolioId = (int)portfolioId;
                    }
                }
            }
        }
        private void CreateClient(Client client)
        {
            string query = "INSERT INTO Clients(ID, Portfolio_ID, First_name, Last_name, Birth_date)"
                + " VALUES(@id, @portfolio_id, @first_name, @last_name, @birth_date)";
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                var command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@id", client.Id);
                command.Parameters.AddWithValue("@first_name", client.FirstName);
                command.Parameters.AddWithValue("@last_name", client.LastName);
                command.Parameters.AddWithValue("@birth_date", client.BirthDate.ToShortDateString());
                if (client.PortfolioId != 0)
                    command.Parameters.AddWithValue("@portfolio_id", client.PortfolioId);
                else
                    command.Parameters.AddWithValue("@portfolio_id", "NULL");
                command.ExecuteNonQuery();
            }
        }
        private void CreateStock(Stock stock)
        {
            string query = "INSERT INTO Stocks(ID, Name, Token)"
                + " VALUES(@id, @name, @token)";
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                var command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@id", stock.Id);
                command.Parameters.AddWithValue("@name", stock.Name);
                command.Parameters.AddWithValue("@token", stock.Token);
                command.ExecuteNonQuery();
            }
        }
        private void DeleteClient(Client client)
        {
            const string query = "DELETE FROM Clients WHERE Id=@id";

            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@id", client.Id);

                command.ExecuteNonQuery();
            }
            if (client.PortfolioId != 0)
            {
                Portfolio portfolio = Portfolio.SavedItems.Find(p => p.Id == client.PortfolioId) as Portfolio;
                DeletePortfolio(portfolio);
            }
        }
        private void DeleteStock(Stock stock)
        {
            const string query = "DELETE FROM Stocks WHERE Id=@id";

            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@id", stock.Id);

                command.ExecuteNonQuery();
            }
        }
        private void DeletePortfolio(Portfolio portfolio)
        {
            const string query = "DELETE FROM Portfolios WHERE Id=@id";

            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@id", portfolio.Id);

                command.ExecuteNonQuery();
            }
        }
        private void UpdateStock(Stock stock)
        {
            const string query = "UPDATE Stocks SET Name=@name, Token=@token WHERE ID=@id";

            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@name", stock.Name);
                command.Parameters.AddWithValue("@token", stock.Token);
                command.Parameters.AddWithValue("@id", stock.Id);
                command.ExecuteNonQuery();
            }
        }
        private void UpdateClient(Client client)
        {
            const string query = "UPDATE Clients SET First_name=@first_name, Last_name=@last_name, Birth_date=@birth_date, Portfolio_ID=@portfolio_id WHERE ID=@id";

            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@first_name", client.FirstName);
                command.Parameters.AddWithValue("@last_name", client.LastName);
                command.Parameters.AddWithValue("@birth_date", client.BirthDate.ToShortDateString());
                command.Parameters.AddWithValue("@id", client.Id);
                if (client.PortfolioId != 0)
                    command.Parameters.AddWithValue("@portfolio_id", client.PortfolioId);
                else
                    command.Parameters.AddWithValue("@portfolio_id", "NULL");
                command.ExecuteNonQuery();
            }
        }
        private void UpdatePortfolio(Portfolio portfolio)
        {
            const string query = "UPDATE Portfolios SET Name=@name WHERE ID=@id";

            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@name", portfolio.Name);
                command.Parameters.AddWithValue("@id", portfolio.Id);
                command.ExecuteNonQuery();
            }
        }

        public static void CreatePortfolio(Portfolio portfolio)
        {
            string query = "INSERT INTO Portfolios(ID, Name)"
                + " VALUES(@id, @name)";
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                var command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@id", portfolio.Id);
                command.Parameters.AddWithValue("@name", portfolio.Name);
                command.ExecuteNonQuery();
            }
        }
        public MainForm()
        {
            InitializeComponent();
            foreach (ColumnHeader column in lvStocks.Columns)
            {
                column.Width = -2;
            }
            foreach (ColumnHeader column in lvClients.Columns)
            {
                column.Width = -2;
            }

            this.KeyPreview = true;

            LoadStocks();
            LoadPortfolios();
            LoadTransactions();
            LoadClients();

            displayStocks();
            displayClients();
        }
        private void displayStocks()
        {
            lvStocks.Items.Clear();
            foreach (var item in Stock.SavedItems)
            {
                Stock stock = item as Stock;
                ListViewItem lvi = new ListViewItem(stock.Name);
                lvi.SubItems.Add(stock.Token);
                lvi.Tag = stock;
                lvStocks.Items.Add(lvi);
            }
        }
        private void displayClients()
        {
            lvClients.Items.Clear();
            foreach (var item in Client.SavedItems)
            {
                Client client = item as Client;
                ListViewItem lvi = new ListViewItem(client.FirstName);
                lvi.SubItems.Add(client.LastName);
                lvi.SubItems.Add(client.BirthDate.ToShortDateString());
                string hasPort = client.PortfolioId == default(int) ? "No" : "Yes";
                lvi.SubItems.Add(hasPort);
                lvi.Tag = client;
                lvClients.Items.Add(lvi);
            }
        }
        private void btnAddStock_Click(object sender, EventArgs e)
        {
            Stock stock = new Stock(string.Empty, string.Empty);
            addEditStock(stock, false);
        }

        private void btnEditStock_Click(object sender, EventArgs e)
        {
            if (lvStocks.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a stock first", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            Stock stock = lvStocks.SelectedItems[0].Tag as Stock;
            addEditStock(stock, true);
        }

        private void addEditStock(Stock stock, bool edit)
        {
            DialogResult diagRes = DialogResult.OK;
            StockForm sf = null;
            StringBuilder name = new StringBuilder(stock.Name);
            StringBuilder token = new StringBuilder(stock.Token);
            string initName = stock.Name;
            string initToken = stock.Token;

            stock.Name = string.Empty;
            stock.Token = string.Empty;

            while (diagRes == DialogResult.OK && (Utils.isEmptyStr(stock.Name) || Utils.isEmptyStr(stock.Token)))
            {
                sf = new StockForm(stock, name, token);
                diagRes = sf.ShowDialog();
            }

            if (diagRes == DialogResult.OK)
            {
                if (!edit)
                    CreateStock(stock);
                else
                    UpdateStock(stock);
                displayStocks();
            }
            else if (!edit)
            {
                stock.removeFromList();
            }
            else
            {
                stock.Name = initName;
                stock.Token = initToken;
            }
        }
        private delegate void DeleteItem<T>(T item);
        private void deleteItems<T>(ListView lv, Action displ, DeleteItem<T> del) where T : class
        {
            if (lv.SelectedItems.Count == 0)
            {
                MessageBox.Show("No items selected", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            string className = lv.SelectedItems[0].Tag.GetType().Name.Replace("Entity<", string.Empty).Replace(">", string.Empty).ToLower();
            DialogResult result = MessageBox.Show($"Are you sure you want to delete the selected {className}s?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes)
            {
                foreach (ListViewItem item in lv.SelectedItems)
                {
                    T obj = item.Tag as T;
                    Entity<T> ent = item.Tag as Entity<T>;
                    del(obj);
                    ent.removeFromList();
                }
                displ();
            }
        }
        private void btnDeleteStock_Click(object sender, EventArgs e)
        {
            deleteItems<Stock>(lvStocks, displayStocks, DeleteStock);
        }

        private void btnAddClient_Click(object sender, EventArgs e)
        {
            Client client = new Client(string.Empty, string.Empty, DateTime.Today.AddDays(-1));
            addEditClient(client, false);
        }
        private void addEditClient(Client client, bool edit)
        {
            DialogResult result = DialogResult.OK;
            ClientForm cf;

            StringBuilder firstName = new StringBuilder(client.FirstName);
            StringBuilder lastName = new StringBuilder(client.LastName);
            DateTime[] birthDateRef = new DateTime[] { client.BirthDate };

            string initFirstName = client.FirstName;
            string initLastName = client.LastName;
            DateTime initBirthDate = client.BirthDate;

            client.FirstName = string.Empty;
            client.LastName = string.Empty;
            client.BirthDate = default(DateTime);

            while (result == DialogResult.OK && (client.FirstName == string.Empty || client.LastName == string.Empty || client.BirthDate == default))
            {
                cf = new ClientForm(client, edit, firstName, lastName, birthDateRef);
                result = cf.ShowDialog();
            }

            if (result == DialogResult.OK)
            {
                if (!edit)
                    CreateClient(client);
                else
                    UpdateClient(client);
                displayClients();
            }
            else if (!edit)
            {
                client.removeFromList();
            }
            else
            {
                client.FirstName = initFirstName;
                client.LastName = initLastName;
                client.BirthDate = initBirthDate;
            }
        }

        private void btnEditClient_Click(object sender, EventArgs e)
        {
            if (lvClients.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a client first", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Client client = lvClients.SelectedItems[0].Tag as Client;
            addEditClient(client, true);
        }

        private void btnDeleteClient_Click(object sender, EventArgs e)
        {
            deleteItems<Client>(lvClients, displayClients, DeleteClient);
        }

        private void btnViewPort_Click(object sender, EventArgs e)
        {
            if (lvClients.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a client first", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Client client = lvClients.SelectedItems[0].Tag as Client;
            if (client.PortfolioId == default)
            {
                DialogResult dRes = MessageBox.Show("Client doesn't have a portfolio, would you like to create one?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dRes == DialogResult.Yes)
                {
                    string portName = $"{client.FirstName} {client.LastName}'s portfolio";
                    Portfolio port = new Portfolio(portName);
                    CreatePortfolio(port);

                    client.PortfolioId = port.Id;
                    UpdateClient(client);
                    displayClients();
                }
                else return;
            }
            Portfolio portfolio = Portfolio.SavedItems.Find(p => p.Id == client.PortfolioId) as Portfolio;
            PortfolioForm pf = new PortfolioForm(portfolio);
            DialogResult result = pf.ShowDialog();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.C)
            {
                btnAddClient_Click(sender, e);
            }
            if (e.Alt && e.KeyCode == Keys.S)
            {
                btnAddStock_Click(sender, e);
            }
        }
    }
}
