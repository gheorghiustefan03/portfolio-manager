namespace PAWProject
{
    partial class PortfolioForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lvTransactions = new ListView();
            colPortDate = new ColumnHeader();
            colPortType = new ColumnHeader();
            colPortStock = new ColumnHeader();
            colPortPrice = new ColumnHeader();
            colPortQuant = new ColumnHeader();
            colPortTotal = new ColumnHeader();
            gbTransactions = new GroupBox();
            btnDelete = new Button();
            btnAdd = new Button();
            btnClose = new Button();
            btnExport = new Button();
            btnGraph = new Button();
            gbTransactions.SuspendLayout();
            SuspendLayout();
            // 
            // lvTransactions
            // 
            lvTransactions.Columns.AddRange(new ColumnHeader[] { colPortDate, colPortType, colPortStock, colPortPrice, colPortQuant, colPortTotal });
            lvTransactions.FullRowSelect = true;
            lvTransactions.Location = new Point(23, 12);
            lvTransactions.MultiSelect = false;
            lvTransactions.Name = "lvTransactions";
            lvTransactions.Size = new Size(637, 413);
            lvTransactions.TabIndex = 0;
            lvTransactions.UseCompatibleStateImageBehavior = false;
            lvTransactions.View = View.Details;
            // 
            // colPortDate
            // 
            colPortDate.Text = "Date";
            // 
            // colPortType
            // 
            colPortType.Text = "Type";
            // 
            // colPortStock
            // 
            colPortStock.Text = "Stock Token";
            // 
            // colPortPrice
            // 
            colPortPrice.Text = "Price";
            // 
            // colPortQuant
            // 
            colPortQuant.Text = "Quantity";
            // 
            // colPortTotal
            // 
            colPortTotal.Text = "Total";
            // 
            // gbTransactions
            // 
            gbTransactions.Controls.Add(btnDelete);
            gbTransactions.Controls.Add(btnAdd);
            gbTransactions.Location = new Point(666, 12);
            gbTransactions.Name = "gbTransactions";
            gbTransactions.Size = new Size(122, 148);
            gbTransactions.TabIndex = 1;
            gbTransactions.TabStop = false;
            gbTransactions.Text = "Transactions";
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(22, 86);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 1;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(22, 38);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnClose
            // 
            btnClose.DialogResult = DialogResult.Cancel;
            btnClose.Location = new Point(694, 396);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(94, 29);
            btnClose.TabIndex = 2;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            // 
            // btnExport
            // 
            btnExport.Location = new Point(688, 176);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(94, 29);
            btnExport.TabIndex = 3;
            btnExport.Text = "Export";
            btnExport.UseVisualStyleBackColor = true;
            btnExport.Click += btnExport_Click;
            // 
            // btnGraph
            // 
            btnGraph.Location = new Point(688, 211);
            btnGraph.Name = "btnGraph";
            btnGraph.Size = new Size(94, 29);
            btnGraph.TabIndex = 4;
            btnGraph.Text = "Graph";
            btnGraph.UseVisualStyleBackColor = true;
            btnGraph.Click += btnGraph_Click;
            // 
            // PortfolioForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnGraph);
            Controls.Add(btnExport);
            Controls.Add(btnClose);
            Controls.Add(gbTransactions);
            Controls.Add(lvTransactions);
            Name = "PortfolioForm";
            gbTransactions.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ListView lvTransactions;
        private GroupBox gbTransactions;
        private Button btnDelete;
        private Button btnAdd;
        private Button btnClose;
        private ColumnHeader colPortType;
        private ColumnHeader colPortStock;
        private ColumnHeader colPortPrice;
        private ColumnHeader colPortQuant;
        private ColumnHeader colPortDate;
        private ColumnHeader colPortTotal;
        private Button btnExport;
        private Button btnGraph;
    }
}