using PAWProject.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PAWProject
{
    public partial class StockForm : Form
    {
        private Stock _stock;
        private StringBuilder _name;
        private StringBuilder _token;
        public StockForm(Stock stock, StringBuilder name, StringBuilder token)
        {
            _stock = stock;
            InitializeComponent();
            _name = name;
            _token = token;
            tbName.Text = name.ToString();
            tbToken.Text = token.ToString();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            _name.Clear();
            _token.Clear();
            _name.Append(tbName.Text);
            _token.Append(tbToken.Text);

            if (!ValidateChildren())
            {
                MessageBox.Show("Form contains one or more errors", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _stock.Name = tbName.Text;
            _stock.Token = tbToken.Text;
        }

        private void tbName_Validating(object sender, CancelEventArgs e)
        {
            if (Utils.isEmptyStr(tbName.Text))
            {
                e.Cancel = true;
                errorProvider.SetError((Control)sender, "Name cannot be empty");
            }
        }

        private void tbName_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError((Control)sender, string.Empty);
        }

        private void tbToken_Validating(object sender, CancelEventArgs e)
        {
            if (Utils.isEmptyStr(tbToken.Text))
            {
                e.Cancel = true;
                errorProvider.SetError((Control)sender, "Token cannot be empty");
            }
        }

        private void tbToken_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError((Control)sender, string.Empty);
        }

        private void tbToken_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
