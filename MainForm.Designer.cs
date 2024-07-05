namespace PAWProject
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lvClients = new ListView();
            colClientFirstName = new ColumnHeader();
            colClientLastName = new ColumnHeader();
            colClientBirthDate = new ColumnHeader();
            colClientPortfolio = new ColumnHeader();
            lvStocks = new ListView();
            colStockName = new ColumnHeader();
            colStockToken = new ColumnHeader();
            gbClients = new GroupBox();
            btnViewPort = new Button();
            btnDeleteClient = new Button();
            btnEditClient = new Button();
            btnAddClient = new Button();
            gbStocks = new GroupBox();
            btnDeleteStock = new Button();
            btnEditStock = new Button();
            btnAddStock = new Button();
            gbClients.SuspendLayout();
            gbStocks.SuspendLayout();
            SuspendLayout();
            // 
            // lvClients
            // 
            lvClients.Columns.AddRange(new ColumnHeader[] { colClientFirstName, colClientLastName, colClientBirthDate, colClientPortfolio });
            lvClients.FullRowSelect = true;
            lvClients.Location = new Point(30, 136);
            lvClients.Name = "lvClients";
            lvClients.Size = new Size(471, 350);
            lvClients.TabIndex = 0;
            lvClients.UseCompatibleStateImageBehavior = false;
            lvClients.View = View.Details;
            // 
            // colClientFirstName
            // 
            colClientFirstName.Text = "First Name";
            // 
            // colClientLastName
            // 
            colClientLastName.Text = "Last Name";
            // 
            // colClientBirthDate
            // 
            colClientBirthDate.Text = "Birth Date";
            // 
            // colClientPortfolio
            // 
            colClientPortfolio.Text = "Has Portfolio";
            // 
            // lvStocks
            // 
            lvStocks.Columns.AddRange(new ColumnHeader[] { colStockName, colStockToken });
            lvStocks.FullRowSelect = true;
            lvStocks.Location = new Point(535, 136);
            lvStocks.Name = "lvStocks";
            lvStocks.Size = new Size(471, 350);
            lvStocks.TabIndex = 1;
            lvStocks.UseCompatibleStateImageBehavior = false;
            lvStocks.View = View.Details;
            // 
            // colStockName
            // 
            colStockName.Text = "Name";
            // 
            // colStockToken
            // 
            colStockToken.Text = "Token";
            // 
            // gbClients
            // 
            gbClients.Controls.Add(btnViewPort);
            gbClients.Controls.Add(btnDeleteClient);
            gbClients.Controls.Add(btnEditClient);
            gbClients.Controls.Add(btnAddClient);
            gbClients.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gbClients.Location = new Point(103, 23);
            gbClients.Name = "gbClients";
            gbClients.Size = new Size(349, 107);
            gbClients.TabIndex = 2;
            gbClients.TabStop = false;
            gbClients.Text = "Clients";
            // 
            // btnViewPort
            // 
            btnViewPort.Location = new Point(179, 64);
            btnViewPort.Name = "btnViewPort";
            btnViewPort.Size = new Size(118, 29);
            btnViewPort.TabIndex = 3;
            btnViewPort.Text = "View Portfolio";
            btnViewPort.UseVisualStyleBackColor = true;
            btnViewPort.Click += btnViewPort_Click;
            // 
            // btnDeleteClient
            // 
            btnDeleteClient.Location = new Point(36, 64);
            btnDeleteClient.Name = "btnDeleteClient";
            btnDeleteClient.Size = new Size(118, 29);
            btnDeleteClient.TabIndex = 2;
            btnDeleteClient.Text = "Delete";
            btnDeleteClient.UseVisualStyleBackColor = true;
            btnDeleteClient.Click += btnDeleteClient_Click;
            // 
            // btnEditClient
            // 
            btnEditClient.Location = new Point(179, 26);
            btnEditClient.Name = "btnEditClient";
            btnEditClient.Size = new Size(118, 29);
            btnEditClient.TabIndex = 1;
            btnEditClient.Text = "Edit";
            btnEditClient.UseVisualStyleBackColor = true;
            btnEditClient.Click += btnEditClient_Click;
            // 
            // btnAddClient
            // 
            btnAddClient.Location = new Point(36, 26);
            btnAddClient.Name = "btnAddClient";
            btnAddClient.Size = new Size(118, 29);
            btnAddClient.TabIndex = 0;
            btnAddClient.Text = "Add";
            btnAddClient.UseVisualStyleBackColor = true;
            btnAddClient.Click += btnAddClient_Click;
            // 
            // gbStocks
            // 
            gbStocks.Controls.Add(btnDeleteStock);
            gbStocks.Controls.Add(btnEditStock);
            gbStocks.Controls.Add(btnAddStock);
            gbStocks.Location = new Point(593, 23);
            gbStocks.Name = "gbStocks";
            gbStocks.Size = new Size(349, 107);
            gbStocks.TabIndex = 3;
            gbStocks.TabStop = false;
            gbStocks.Text = "Stocks";
            // 
            // btnDeleteStock
            // 
            btnDeleteStock.Location = new Point(130, 61);
            btnDeleteStock.Name = "btnDeleteStock";
            btnDeleteStock.Size = new Size(118, 29);
            btnDeleteStock.TabIndex = 4;
            btnDeleteStock.Text = "Delete";
            btnDeleteStock.UseVisualStyleBackColor = true;
            btnDeleteStock.Click += btnDeleteStock_Click;
            // 
            // btnEditStock
            // 
            btnEditStock.Location = new Point(202, 26);
            btnEditStock.Name = "btnEditStock";
            btnEditStock.Size = new Size(118, 29);
            btnEditStock.TabIndex = 4;
            btnEditStock.Text = "Edit";
            btnEditStock.UseVisualStyleBackColor = true;
            btnEditStock.Click += btnEditStock_Click;
            // 
            // btnAddStock
            // 
            btnAddStock.Location = new Point(51, 26);
            btnAddStock.Name = "btnAddStock";
            btnAddStock.Size = new Size(118, 29);
            btnAddStock.TabIndex = 4;
            btnAddStock.Text = "Add";
            btnAddStock.UseVisualStyleBackColor = true;
            btnAddStock.Click += btnAddStock_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1043, 530);
            Controls.Add(gbStocks);
            Controls.Add(gbClients);
            Controls.Add(lvStocks);
            Controls.Add(lvClients);
            Name = "MainForm";
            Text = "Stocks/Portfolios Tracker";
            KeyDown += MainForm_KeyDown;
            gbClients.ResumeLayout(false);
            gbStocks.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ListView lvClients;
        private ListView lvStocks;
        private GroupBox gbClients;
        private GroupBox gbStocks;
        private Button btnViewPort;
        private Button btnDeleteClient;
        private Button btnEditClient;
        private Button btnAddClient;
        private Button btnDeleteStock;
        private Button btnEditStock;
        private Button btnAddStock;
        private ColumnHeader colStockName;
        private ColumnHeader colStockToken;
        private ColumnHeader colClientFirstName;
        private ColumnHeader colClientLastName;
        private ColumnHeader colClientBirthDate;
        private ColumnHeader colClientPortfolio;
    }
}
