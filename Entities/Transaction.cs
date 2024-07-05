using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PAWProject.Entities
{
    public enum TransactionType
    {
        BUY, SELL
    }
    internal class NoStockException : Exception
    {
        private int Id;
        public NoStockException(int id)
        {
            Id = id;
        }
        public override string Message
        {
            get
            {
                return "Stock with ID " + Id + " doesn't exist";
            }
        }
    }
    internal class SellMoreThanBuyException : Exception
    {
        private DateTime TransactionDate;
        private int Quantity;
        private bool Sell;
        public SellMoreThanBuyException(DateTime transactionDate, int quantity, bool sell)
        {
            TransactionDate = transactionDate;
            Quantity = quantity;
            Sell = sell;
        }
        public override string Message
        {
            get
            {
                if (Sell)
                    return "Can't sell " + Quantity + " of the stock at date " + TransactionDate.ToShortDateString() + ".";
                else
                    return "Can't delete remove BUY transaction at date " + TransactionDate.ToShortDateString() + ", quantity - " + Quantity + ", further SELL transactions in this portfolio depend on it";
            }
        }
    }
    internal class InvalidTransactionDateException : Exception
    {
        private DateTime TransactionDate;
        public InvalidTransactionDateException(DateTime transactionDate)
        {
            TransactionDate = transactionDate;
        }
        public override string Message
        {
            get
            {
                return "Transaction date " + TransactionDate.ToShortDateString() + " invalid";
            }
        }
    }
    internal class InvalidPriceException : Exception
    {
        private decimal Price;
        public InvalidPriceException(decimal price)
        {
            Price = price;
        }
        public override string Message
        {
            get
            {
                return "Price (" + Price + ") cannot be negative or 0";
            }
        }
    }
    internal class InvalidQuantityException : Exception
    {
        private int Quantity;
        public InvalidQuantityException(int quantity)
        {
            Quantity = quantity;
        }
        public override string Message
        {
            get
            {
                return "Quantity (" + Quantity + ") cannot be negative or 0";
            }
        }
    }
    public class Transaction : Entity<Transaction>
    {

        private int _stockId;
        public int StockId
        {
            get
            {
                return _stockId;
            }
            set
            {
                if (!Stock.SavedItems.Any(stock => stock.Id == value))
                    throw new NoStockException(value);
                _stockId = value;
            }
        }

        private DateTime _date;
        public DateTime Date
        {
            get { return _date; }
            set
            {
                if ((value.Year > DateTime.Today.Year) ||
                    (value.Year == DateTime.Today.Year && value.Month > DateTime.Today.Month) ||
                    (value.Year == DateTime.Today.Year && value.Month == DateTime.Today.Month && value.Day > DateTime.Today.Day))
                    throw new InvalidTransactionDateException(value);
                _date = value;
            }
        }

        private decimal _price;
        public decimal Price
        {
            get { return _price; }
            set
            {
                if (value <= 0)
                    throw new InvalidPriceException(value);
                _price = value;
            }
        }

        private int _quantity;
        public int Quantity
        {
            get { return _quantity; }
            set
            {
                if (value <= 0)
                    throw new InvalidQuantityException(value);
                _quantity = value;
            }
        }
        public TransactionType Type { get; set; }
        private Portfolio _holdingPortfolio;

        public Transaction(TransactionType type, int stockId, DateTime date, decimal price, int quantity,
            Portfolio holdingPortfolio) : base()
        {
            Type = type;
            StockId = stockId;
            Date = date;
            Price = price;
            Quantity = quantity;
            _holdingPortfolio = holdingPortfolio;
        }

        public void checkValidSell()
        {
            if (Type == TransactionType.SELL)
            {
                int quantAtDate = 0;
                List<Entity<Transaction>> transactions = getTransactionsInPortfolio(_holdingPortfolio);
                foreach (var transactionEnt in transactions)
                {
                    Transaction transaction = transactionEnt as Transaction;
                    if (transaction.Date <= Date && (transaction.StockId == StockId))
                    {
                        if (transaction.Type == TransactionType.SELL)
                            quantAtDate -= transaction.Quantity;
                        else
                            quantAtDate += transaction.Quantity;
                    }
                }
                if (quantAtDate < Quantity)
                    throw new SellMoreThanBuyException(Date, Quantity, true);
            }
        }

        private static List<Entity<Transaction>> getTransactionsInPortfolio(Portfolio port)
        {
            List<Entity<Transaction>> result = new List<Entity<Transaction>>();
            foreach (var tId in port.TransactionIds)
            {
                result.Add(SavedItems.Find(transaction => transaction.Id == tId));
            }
            return result;
        }

        public bool checkValidDelBuy()
        {
            if (Type == TransactionType.BUY)
            {
                List<Entity<Transaction>> transactions = getTransactionsInPortfolio(_holdingPortfolio);
                int heldStocks = 0;
                foreach (var transactionEnt in transactions)
                {
                    Transaction transaction = transactionEnt as Transaction;
                    if(transaction != this)
                    {
                        if (transaction.Type == TransactionType.BUY)
                            heldStocks += transaction.Quantity;
                        else
                            heldStocks -= transaction.Quantity;
                    }
                    if (heldStocks < 0)
                        return false;
                }
            }
            return true;
        }
        public override void removeFromList()
        {
            if(!checkValidDelBuy())
                throw new SellMoreThanBuyException(Date, Quantity, false);
            SavedItems.Remove(this);
        }
    }
}
