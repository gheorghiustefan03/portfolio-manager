using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAWProject.Entities
{
    internal class NoTransactionException : Exception
    {
        private int Id;
        public NoTransactionException(int id)
        {
            Id = id;
        }
        public override string Message
        {
            get
            {
                return "Transaction with ID " + Id + " doesn't exist";
            }
        }
    }
    public class Portfolio : Entity<Portfolio>
    {
        private List<int> _transactionIds;
        public int[] TransactionIds
        {
            get
            {
                int[] stockIdsCopy = new int[_transactionIds.Count];
                _transactionIds.CopyTo(stockIdsCopy, 0);
                return stockIdsCopy;
            }
            set
            {
                foreach(var transactionId in value)
                {
                    addTransaction(transactionId);
                }
            }
        }
        public void addTransaction(int id)
        {
            if(!Transaction.SavedItems.Any(transaction => transaction.Id == id))
                throw new NoTransactionException(id);
            _transactionIds.Add(id);
        }
        public void removeTransaction(int id)
        {
            Transaction transaction = Transaction.SavedItems.Find(transaction => transaction.Id == id) as Transaction;
            if (transaction == null)
                throw new NoTransactionException(id);
            if (!transaction.checkValidDelBuy())
                throw new SellMoreThanBuyException(transaction.Date, transaction.Quantity, false);
            _transactionIds.Remove(id);
        }

        public string Name { get; set; }

        public Portfolio(string name) :base()
        {
            Name = name;
            _transactionIds = new List<int>();
        }
        public Portfolio(string name, int[] transactionIds):this(name)
        {
            TransactionIds = transactionIds;
        }
    }

}
