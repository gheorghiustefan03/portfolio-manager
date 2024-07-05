namespace PAWProject
{
    partial class ClientForm
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
            gbClientInfo = new GroupBox();
            cbGeneratePort = new CheckBox();
            dtpBirthDate = new DateTimePicker();
            tbLastName = new TextBox();
            tbFirstName = new TextBox();
            lbBirthDate = new Label();
            lbLastName = new Label();
            lbFirstName = new Label();
            errorProvider = new ErrorProvider(components);
            btnConfirm = new Button();
            btnCancel = new Button();
            gbClientInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // gbClientInfo
            // 
            gbClientInfo.Controls.Add(cbGeneratePort);
            gbClientInfo.Controls.Add(dtpBirthDate);
            gbClientInfo.Controls.Add(tbLastName);
            gbClientInfo.Controls.Add(tbFirstName);
            gbClientInfo.Controls.Add(lbBirthDate);
            gbClientInfo.Controls.Add(lbLastName);
            gbClientInfo.Controls.Add(lbFirstName);
            gbClientInfo.Location = new Point(48, 71);
            gbClientInfo.Name = "gbClientInfo";
            gbClientInfo.Size = new Size(422, 234);
            gbClientInfo.TabIndex = 0;
            gbClientInfo.TabStop = false;
            gbClientInfo.Text = "Client Info";
            // 
            // cbGeneratePort
            // 
            cbGeneratePort.AutoSize = true;
            cbGeneratePort.Location = new Point(139, 166);
            cbGeneratePort.Name = "cbGeneratePort";
            cbGeneratePort.Size = new Size(152, 24);
            cbGeneratePort.TabIndex = 8;
            cbGeneratePort.Text = "Generate Portfolio";
            cbGeneratePort.UseVisualStyleBackColor = true;
            // 
            // dtpBirthDate
            // 
            dtpBirthDate.Location = new Point(139, 115);
            dtpBirthDate.Name = "dtpBirthDate";
            dtpBirthDate.Size = new Size(250, 27);
            dtpBirthDate.TabIndex = 7;
            dtpBirthDate.Validating += dtpBirthDate_Validating;
            dtpBirthDate.Validated += dtpBirthDate_Validated;
            // 
            // tbLastName
            // 
            tbLastName.Location = new Point(139, 77);
            tbLastName.Name = "tbLastName";
            tbLastName.Size = new Size(250, 27);
            tbLastName.TabIndex = 5;
            tbLastName.Validating += tbLastName_Validating;
            tbLastName.Validated += tbLastName_Validated;
            // 
            // tbFirstName
            // 
            tbFirstName.Location = new Point(139, 38);
            tbFirstName.Name = "tbFirstName";
            tbFirstName.Size = new Size(250, 27);
            tbFirstName.TabIndex = 4;
            tbFirstName.KeyPress += tbFirstName_KeyPress;
            tbFirstName.Validating += tbFirstName_Validating;
            tbFirstName.Validated += tbFirstName_Validated;
            // 
            // lbBirthDate
            // 
            lbBirthDate.AutoSize = true;
            lbBirthDate.Location = new Point(55, 120);
            lbBirthDate.Name = "lbBirthDate";
            lbBirthDate.Size = new Size(76, 20);
            lbBirthDate.TabIndex = 2;
            lbBirthDate.Text = "Birth Date";
            // 
            // lbLastName
            // 
            lbLastName.AutoSize = true;
            lbLastName.Location = new Point(55, 80);
            lbLastName.Name = "lbLastName";
            lbLastName.Size = new Size(79, 20);
            lbLastName.TabIndex = 1;
            lbLastName.Text = "Last Name";
            // 
            // lbFirstName
            // 
            lbFirstName.AutoSize = true;
            lbFirstName.Location = new Point(55, 41);
            lbFirstName.Name = "lbFirstName";
            lbFirstName.Size = new Size(80, 20);
            lbFirstName.TabIndex = 0;
            lbFirstName.Text = "First Name";
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // btnConfirm
            // 
            btnConfirm.DialogResult = DialogResult.OK;
            btnConfirm.Location = new Point(103, 325);
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
            btnCancel.Location = new Point(343, 325);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // ClientForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.EnableAllowFocusChange;
            ClientSize = new Size(531, 397);
            Controls.Add(btnCancel);
            Controls.Add(btnConfirm);
            Controls.Add(gbClientInfo);
            Name = "ClientForm";
            Text = "Add/Edit Client";
            gbClientInfo.ResumeLayout(false);
            gbClientInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gbClientInfo;
        private CheckBox cbGeneratePort;
        private DateTimePicker dtpBirthDate;
        private TextBox tbLastName;
        private TextBox tbFirstName;
        private Label lbBirthDate;
        private Label lbLastName;
        private Label lbFirstName;
        private ErrorProvider errorProvider;
        private Button btnCancel;
        private Button btnConfirm;
    }
}