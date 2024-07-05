namespace PAWProject
{
    partial class StockForm
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
            components = new System.ComponentModel.Container();
            gbStockInfo = new GroupBox();
            tbToken = new TextBox();
            tbName = new TextBox();
            lbToken = new Label();
            lbName = new Label();
            btnConfirm = new Button();
            btnCancel = new Button();
            errorProvider = new ErrorProvider(components);
            gbStockInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // gbStockInfo
            // 
            gbStockInfo.Controls.Add(tbToken);
            gbStockInfo.Controls.Add(tbName);
            gbStockInfo.Controls.Add(lbToken);
            gbStockInfo.Controls.Add(lbName);
            gbStockInfo.Location = new Point(50, 52);
            gbStockInfo.Name = "gbStockInfo";
            gbStockInfo.Size = new Size(273, 202);
            gbStockInfo.TabIndex = 0;
            gbStockInfo.TabStop = false;
            gbStockInfo.Text = "Stock Information";
            // 
            // tbToken
            // 
            tbToken.Location = new Point(117, 122);
            tbToken.Name = "tbToken";
            tbToken.Size = new Size(125, 27);
            tbToken.TabIndex = 3;
            tbToken.KeyPress += tbToken_KeyPress;
            tbToken.Validating += tbToken_Validating;
            tbToken.Validated += tbToken_Validated;
            // 
            // tbName
            // 
            tbName.Location = new Point(117, 62);
            tbName.Name = "tbName";
            tbName.Size = new Size(125, 27);
            tbName.TabIndex = 2;
            tbName.Validating += tbName_Validating;
            tbName.Validated += tbName_Validated;
            // 
            // lbToken
            // 
            lbToken.AutoSize = true;
            lbToken.Location = new Point(46, 129);
            lbToken.Name = "lbToken";
            lbToken.Size = new Size(48, 20);
            lbToken.TabIndex = 1;
            lbToken.Text = "Token";
            // 
            // lbName
            // 
            lbName.AutoSize = true;
            lbName.Location = new Point(46, 65);
            lbName.Name = "lbName";
            lbName.Size = new Size(49, 20);
            lbName.TabIndex = 0;
            lbName.Text = "Name";
            // 
            // btnConfirm
            // 
            btnConfirm.DialogResult = DialogResult.OK;
            btnConfirm.Location = new Point(349, 114);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(94, 29);
            btnConfirm.TabIndex = 1;
            btnConfirm.Text = "Confirm";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(349, 174);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // StockForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.EnableAllowFocusChange;
            ClientSize = new Size(494, 318);
            Controls.Add(btnCancel);
            Controls.Add(btnConfirm);
            Controls.Add(gbStockInfo);
            Name = "StockForm";
            Text = "Add/Edit Stock";
            gbStockInfo.ResumeLayout(false);
            gbStockInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gbStockInfo;
        private Label lbToken;
        private Label lbName;
        private TextBox tbToken;
        private TextBox tbName;
        private Button btnConfirm;
        private Button btnCancel;
        private ErrorProvider errorProvider;
    }
}