using PAWProject.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PAWProject
{
    public partial class ClientForm : Form
    {
        private const string ConnectionString = "Data Source=db.sqlite";

        private StringBuilder _firstName;
        private StringBuilder _lastName;
        private DateTime[] _birthDateRef;
        private Client _client;
        public ClientForm(Client client,
            bool edit, StringBuilder firstName, StringBuilder lastName, DateTime[]birthDateRef)
        {
            InitializeComponent();
            _firstName = firstName;
            _lastName = lastName;
            _birthDateRef = birthDateRef;
            _client = client;
            if (edit)
                cbGeneratePort.Visible = false;
            tbFirstName.Text = firstName.ToString();
            tbLastName.Text = lastName.ToString();
            dtpBirthDate.Value = _birthDateRef[0];
        }


        private void tbFirstName_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError((Control)sender, string.Empty);
        }

        private void tbFirstName_Validating(object sender, CancelEventArgs e)
        {
            if (Utils.isEmptyStr(tbFirstName.Text))
            {
                e.Cancel = true;
                errorProvider.SetError((Control)sender, "First name cannot be empty");
            }
        }

        private void tbLastName_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError((Control)sender, string.Empty);
        }

        private void tbLastName_Validating(object sender, CancelEventArgs e)
        {
            if (Utils.isEmptyStr(tbLastName.Text))
            {
                e.Cancel = true;
                errorProvider.SetError((Control)sender, "Last name cannot be empty");
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            _firstName.Clear();
            _lastName.Clear();
            _firstName.Append(tbFirstName.Text);
            _lastName.Append(tbLastName.Text);
            _birthDateRef[0] = dtpBirthDate.Value;

            if (!ValidateChildren())
            {
                MessageBox.Show("Form contains one or more errors", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _client.FirstName = tbFirstName.Text;
            _client.LastName = tbLastName.Text;
            _client.BirthDate = dtpBirthDate.Value;

            if (cbGeneratePort.Checked)
            {
                string portName = $"{_client.FirstName} {_client.LastName}'s portfolio";
                Portfolio port = new Portfolio(portName);
                MainForm.CreatePortfolio(port);
                
                _client.PortfolioId = port.Id;
            }
        }

        private void tbFirstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsAsciiLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dtpBirthDate_Validating(object sender, CancelEventArgs e)
        {
            int age = DateTime.Today.Year - dtpBirthDate.Value.Year;
            if ((dtpBirthDate.Value.Month == DateTime.Today.Month && dtpBirthDate.Value.Day > DateTime.Today.Day)
                || dtpBirthDate.Value.Month > DateTime.Today.Month)
                age--;
            if (age < 18)
            {
                e.Cancel = true;
                errorProvider.SetError((Control)sender, "Client must be at least 18 to register");
            }
        }

        private void dtpBirthDate_Validated(object sender, EventArgs e)
        {
            errorProvider.SetError((Control)sender, string.Empty);
        }
    }
}
