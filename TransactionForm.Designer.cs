namespace PAWProject
{
    partial class TransactionForm
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
            cbTransType = new ComboBox();
            lbTransType = new Label();
            lbTransStock = new Label();
            cbTransStock = new ComboBox();
            nudTransPrice = new NumericUpDown();
            nudTransQuant = new NumericUpDown();
            lbTransQuant = new Label();
            lbTransPrice = new Label();
            dtpTransDate = new DateTimePicker();
            lbTransDate = new Label();
            btnAdd = new Button();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)nudTransPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudTransQuant).BeginInit();
            SuspendLayout();
            // 
            // cbTransType
            // 
            cbTransType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTransType.FormattingEnabled = true;
            cbTransType.Location = new Point(126, 43);
            cbTransType.Name = "cbTransType";
            cbTransType.Size = new Size(250, 28);
            cbTransType.TabIndex = 0;
            // 
            // lbTransType
            // 
            lbTransType.AutoSize = true;
            lbTransType.Location = new Point(44, 46);
            lbTransType.Name = "lbTransType";
            lbTransType.Size = new Size(40, 20);
            lbTransType.TabIndex = 1;
            lbTransType.Text = "Type";
            // 
            // lbTransStock
            // 
            lbTransStock.AutoSize = true;
            lbTransStock.Location = new Point(44, 93);
            lbTransStock.Name = "lbTransStock";
            lbTransStock.Size = new Size(45, 20);
            lbTransStock.TabIndex = 2;
            lbTransStock.Text = "Stock";
            // 
            // cbTransStock
            // 
            cbTransStock.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTransStock.FormattingEnabled = true;
            cbTransStock.Location = new Point(126, 90);
            cbTransStock.Name = "cbTransStock";
            cbTransStock.Size = new Size(250, 28);
            cbTransStock.TabIndex = 3;
            // 
            // nudTransPrice
            // 
            nudTransPrice.DecimalPlaces = 2;
            nudTransPrice.Location = new Point(126, 139);
            nudTransPrice.Name = "nudTransPrice";
            nudTransPrice.Size = new Size(250, 27);
            nudTransPrice.TabIndex = 4;
            // 
            // nudTransQuant
            // 
            nudTransQuant.Location = new Point(126, 187);
            nudTransQuant.Name = "nudTransQuant";
            nudTransQuant.Size = new Size(250, 27);
            nudTransQuant.TabIndex = 5;
            nudTransQuant.KeyPress += nudTransQuant_KeyPress;
            // 
            // lbTransQuant
            // 
            lbTransQuant.AutoSize = true;
            lbTransQuant.Location = new Point(44, 189);
            lbTransQuant.Name = "lbTransQuant";
            lbTransQuant.Size = new Size(65, 20);
            lbTransQuant.TabIndex = 6;
            lbTransQuant.Text = "Quantity";
            // 
            // lbTransPrice
            // 
            lbTransPrice.AutoSize = true;
            lbTransPrice.Location = new Point(44, 141);
            lbTransPrice.Name = "lbTransPrice";
            lbTransPrice.Size = new Size(41, 20);
            lbTransPrice.TabIndex = 7;
            lbTransPrice.Text = "Price";
            // 
            // dtpTransDate
            // 
            dtpTransDate.Location = new Point(126, 231);
            dtpTransDate.Name = "dtpTransDate";
            dtpTransDate.Size = new Size(250, 27);
            dtpTransDate.TabIndex = 8;
            // 
            // lbTransDate
            // 
            lbTransDate.AutoSize = true;
            lbTransDate.Location = new Point(44, 236);
            lbTransDate.Name = "lbTransDate";
            lbTransDate.Size = new Size(41, 20);
            lbTransDate.TabIndex = 9;
            lbTransDate.Text = "Date";
            // 
            // btnAdd
            // 
            btnAdd.DialogResult = DialogResult.OK;
            btnAdd.Location = new Point(126, 288);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 10;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(282, 288);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 11;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // TransactionForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(457, 345);
            Controls.Add(btnCancel);
            Controls.Add(btnAdd);
            Controls.Add(lbTransDate);
            Controls.Add(dtpTransDate);
            Controls.Add(lbTransPrice);
            Controls.Add(lbTransQuant);
            Controls.Add(nudTransQuant);
            Controls.Add(nudTransPrice);
            Controls.Add(cbTransStock);
            Controls.Add(lbTransStock);
            Controls.Add(lbTransType);
            Controls.Add(cbTransType);
            Name = "TransactionForm";
            Text = "Add Transaction";
            ((System.ComponentModel.ISupportInitialize)nudTransPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudTransQuant).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cbTransType;
        private Label lbTransType;
        private Label lbTransStock;
        private ComboBox cbTransStock;
        private NumericUpDown nudTransPrice;
        private NumericUpDown nudTransQuant;
        private Label lbTransQuant;
        private Label lbTransPrice;
        private DateTimePicker dtpTransDate;
        private Label lbTransDate;
        private Button btnAdd;
        private Button btnCancel;
    }
}