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
    public partial class TransactionForm : Form
    {
        private Transaction _transaction;
        private decimal[] _priceRef;
        private int[] _quantityRef;
        private DateTime[] _dateRef;
        private TransactionType[] _typeRef;
        private Stock[] _stockRef;
        public TransactionForm(Transaction transaction, decimal[] priceRef, int[] quantityRef, DateTime[] dateRef, TransactionType[] typeRef, Stock[] stockRef)
        {
            InitializeComponent();

            _transaction = transaction;
            _priceRef = priceRef;
            _quantityRef = quantityRef;
            _dateRef = dateRef;
            _stockRef = stockRef;
            _typeRef = typeRef;

            cbTransType.DisplayMember = "TypeKey";
            cbTransType.ValueMember = "TypeVal";
            cbTransType.DataSource = new TypeComboItem[]
            {
                new TypeComboItem("SELL", TransactionType.SELL),
                new TypeComboItem("BUY", TransactionType.BUY)
            };
            int typeIndex = cbTransType.FindString(_typeRef[0].ToString());
            cbTransType.SelectedIndex = typeIndex;
            cbTransType.Refresh();
            cbTransStock.DisplayMember = "StockKey";
            cbTransStock.ValueMember = "StockVal";
            List<StockComboItem> stockComboItems = new List<StockComboItem>();
            foreach (Entity<Stock> stockEnt in Stock.SavedItems)
            {
                Stock stockObj = stockEnt as Stock;
                StockComboItem sbi = new StockComboItem(stockObj.Token, stockObj);
                stockComboItems.Add(sbi);
            }
            cbTransStock.DataSource = stockComboItems;
            int stockIndex = cbTransStock.FindString(_stockRef[0].Token.ToString());
            cbTransStock.SelectedIndex = stockIndex;
            cbTransStock.Refresh();
            nudTransPrice.Maximum = decimal.MaxValue;
            nudTransQuant.Maximum = int.MaxValue;

            nudTransPrice.Value = _priceRef[0];
            nudTransQuant.Value = _quantityRef[0];
            dtpTransDate.Value = _dateRef[0];
        }
        internal class TypeComboItem
        {
            public string TypeKey { get; set; }
            public TransactionType TypeVal { get; set; }
            public TypeComboItem(string typeKey, TransactionType typeVal)
            {
                TypeKey = typeKey;
                TypeVal = typeVal;
            }
        }
        internal class StockComboItem
        {
            public string StockKey { get; set; }
            public Stock StockVal { get; set; }
            public StockComboItem(string stockKey, Stock stockVal)
            {
                StockKey = stockKey;
                StockVal = stockVal;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _priceRef[0] = nudTransPrice.Value;
            _quantityRef[0] = (int)nudTransQuant.Value;
            _dateRef[0] = dtpTransDate.Value;
            _stockRef[0] = cbTransStock.SelectedValue as Stock;
            _dateRef[0] = dtpTransDate.Value;
            _typeRef[0] = (TransactionType)cbTransType.SelectedValue;

            if (!ValidateChildren())
            {
                MessageBox.Show("Form contains one or more errors", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _transaction.Type = (TransactionType)cbTransType.SelectedValue;
            _transaction.StockId = ((Stock)cbTransStock.SelectedValue).Id;
            _transaction.Price = nudTransPrice.Value;
            _transaction.Quantity = (int)nudTransQuant.Value;
            _transaction.Date = dtpTransDate.Value;
        }

        private void nudTransQuant_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)
                e.Handled = true;
        }
    }
}