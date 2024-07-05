using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PAWProject.Entities;

namespace PAWProject
{
    public partial class PortfolioForm : Form
    {
        private const string ConnectionString = "Data Source=db.sqlite";

        private Portfolio _portfolio;
        public PortfolioForm(Portfolio portfolio)
        {
            InitializeComponent();
            foreach (ColumnHeader column in lvTransactions.Columns)
            {
                column.Width = -2;
            }
            _portfolio = portfolio;
            Text = _portfolio.Name;
            Update();
            displayTransactions();
        }

        private static int sortByDate(Transaction x, Transaction y)
        {
            if (x.Date.Date == y.Date.Date)
            {
                if (x.Type == y.Type)
                    return 0;
                else if (x.Type == TransactionType.BUY)
                    return -1;
                else return 1;
            }
            else if (y.Date.Date > x.Date.Date)
                return 1;
            else return -1;
        }
        private void displayTransactions()
        {
            lvTransactions.Items.Clear();
            List<Transaction> currentTransactions = new List<Transaction>();
            foreach (int id in _portfolio.TransactionIds)
            {
                Transaction transaction = Transaction.SavedItems.Find(t => t.Id == id) as Transaction;
                currentTransactions.Add(transaction);
            }
            currentTransactions.Sort(sortByDate);
            foreach (Transaction transaction in currentTransactions)
            {
                ListViewItem lvi = new ListViewItem(transaction.Date.ToShortDateString());
                lvi.SubItems.Add(transaction.Type.ToString());
                Stock stock = Stock.SavedItems.Find(s => s.Id == transaction.StockId) as Stock;
                lvi.SubItems.Add(stock.Token);
                lvi.SubItems.Add(transaction.Price.ToString());
                lvi.SubItems.Add(transaction.Quantity.ToString());
                lvi.SubItems.Add((transaction.Price * transaction.Quantity).ToString());
                lvi.Tag = transaction;
                lvTransactions.Items.Add(lvi);
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Stock.SavedItems.Count == 0)
            {
                MessageBox.Show("Please add some stocks first", "No stocks", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult res = DialogResult.OK;

            TransactionType[] transactionTypeRef = new TransactionType[] { TransactionType.BUY };
            Stock[] firstStockRef = new Stock[] { Stock.SavedItems[0] as Stock };
            decimal[] priceRef = new decimal[] { 0 };
            int[] quantityRef = new int[] { 0 };
            DateTime[] dateRef = new DateTime[] { DateTime.Today };

            Transaction transaction = new Transaction(TransactionType.BUY, firstStockRef[0].Id, default, decimal.MaxValue, int.MaxValue, _portfolio);
            bool valid = false;
            while (res == DialogResult.OK && (transaction.Quantity == int.MaxValue || transaction.Price == decimal.MaxValue
                || transaction.Date == default || !valid))
            {
                valid = true;
                TransactionForm tf = new TransactionForm(transaction, priceRef, quantityRef, dateRef, transactionTypeRef, firstStockRef);
                res = tf.ShowDialog();
                if (!(transaction.Quantity == int.MaxValue || transaction.Price == decimal.MaxValue
                || transaction.Date == default) && res == DialogResult.OK)
                {
                    try
                    {
                        transaction.checkValidSell();
                    }
                    catch (Exception smtbe)
                    {
                        valid = false;
                        MessageBox.Show("Error: " + smtbe.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            if (res == DialogResult.OK)
            {
                _portfolio.addTransaction(transaction.Id);
                CreateTransaction(transaction);
                displayTransactions();
            }
            else
            {
                transaction.removeFromList();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvTransactions.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a transaction first", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Are you sure you want to delete the selected transaction?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Transaction transaction = lvTransactions.SelectedItems[0].Tag as Transaction;
                _portfolio.removeTransaction(transaction.Id);
                transaction.removeFromList();
                DeleteTransaction(transaction);
                displayTransactions();
            }
        }

        private void CreateTransaction(Transaction transaction)
        {
            string query = "INSERT INTO Transactions(ID, Stock_ID, Date, Price, Quantity, Type, Portfolio_ID)"
                + " VALUES(@id, @stock_id, @date, @price, @quantity, @type, @portfolio_id)";
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                var command = new SQLiteCommand(query, connection);
                string strType = "";
                switch (transaction.Type)
                {
                    case TransactionType.BUY:
                        strType = "BUY";
                        break;
                    case TransactionType.SELL:
                        strType = "SELL";
                        break;
                }
                command.Parameters.AddWithValue("@id", transaction.Id);
                command.Parameters.AddWithValue("@stock_id", transaction.StockId);
                command.Parameters.AddWithValue("@date", transaction.Date.ToShortDateString());
                command.Parameters.AddWithValue("@price", transaction.Price);
                command.Parameters.AddWithValue("@quantity", transaction.Quantity);
                command.Parameters.AddWithValue("@type", strType);
                command.Parameters.AddWithValue("@portfolio_id", _portfolio.Id);
                command.ExecuteNonQuery();
            }
        }

        private void DeleteTransaction(Transaction transaction)
        {
            const string query = "DELETE FROM Transactions WHERE Id=@id";

            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@id", transaction.Id);

                command.ExecuteNonQuery();
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text File | *.txt";
            saveFileDialog.Title = "Save as text file";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = File.CreateText(saveFileDialog.FileName))
                {
                    sw.WriteLine("Date\t\t Type\t Stock\t Price\t Quantity\t Total");

                    foreach (int id in _portfolio.TransactionIds)
                    {
                        Transaction t = Transaction.SavedItems.Find(t => t.Id == id) as Transaction;
                        Stock s = Stock.SavedItems.Find(s => s.Id == t.StockId) as Stock;
                        sw.WriteLine("{0}\t {1}\t {2}\t {3}\t {4}\t\t {5}"
                                    , t.Date.ToShortDateString()
                                    , t.Type.ToString()
                                    , s.Token
                                    , t.Price.ToString()
                                    , t.Quantity.ToString()
                                    , (t.Price * t.Quantity).ToString());
                    }

                }

            }
        }

        private void btnGraph_Click(object sender, EventArgs e)
        {
            if(_portfolio.TransactionIds.Length != 0)
            {
                List<Entity<Transaction>> transEntList = Transaction.SavedItems.FindAll(tEnt =>
                {
                    Transaction t = tEnt as Transaction;
                    return _portfolio.TransactionIds.Contains(t.Id);
                });
                List<Transaction> transList = new List<Transaction>();
                foreach (Entity<Transaction> ent in transEntList)
                {
                    transList.Add(ent as Transaction);
                }
                transList.Sort(sortByDate);
                List<DateTime> dates = new List<DateTime>();
                List<decimal> profits = new List<decimal>();
                decimal profit = 0;
                foreach (Transaction t in transList)
                {
                    dates.Add(t.Date);
                }
                dates = dates.Distinct().Reverse().ToList();
                foreach (var date in dates)
                {
                    List<Transaction> transactionsOnDate = transList.FindAll(t => t.Date == date);
                    foreach (var t in transactionsOnDate)
                    {
                        switch (t.Type)
                        {
                            case TransactionType.BUY:
                                profit += t.Price * t.Quantity;
                                break;
                            case TransactionType.SELL:
                                profit -= t.Price * t.Quantity;
                                break;
                        }
                    }
                    profits.Add(profit);
                }
                GraphForm graphForm = new GraphForm(dates, profits);
                graphForm.Show();
            }
            
        }
    }
}
