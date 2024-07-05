using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAWProject.Entities
{
    internal class NoPortfolioException: Exception
    {
        private int Id;
        public NoPortfolioException(int id)
        {
            Id = id;
        }
        public override string Message
        {
            get
            {
                return "Portfolio with ID " + Id + " doesn't exist";
            }
        }
    }
    internal class InvalidBirthDateException : Exception
    {
        private DateTime BirthDate;
        public InvalidBirthDateException(DateTime birthDate)
        {
            BirthDate = birthDate;
        }
        public override string Message
        {
            get
            {
                return "Birth date " + BirthDate.ToShortDateString() + " invalid";
            }
        }
    }
    public class Client : Entity<Client>
    {
        private int _portfolioId;
        public int PortfolioId
        {
            get { return _portfolioId; }
            set
            {
                if (!Portfolio.SavedItems.Any(portfolio => portfolio.Id == value))
                    throw new NoPortfolioException(value);
                _portfolioId = value;
            }
        }
        private string _firstName;
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                if (value == string.Empty)
                {
                    _firstName = value;
                    return;
                }
                _firstName = value.Trim().Substring(0, 1).ToUpper() + value.Trim().Substring(1).ToLower();
            }
        }
        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (value == string.Empty)
                {
                    _lastName = value;
                    return;
                }
                _lastName = value.Trim().Substring(0, 1).ToUpper() + value.Trim().Substring(1).ToLower();
            }
        }
        private DateTime _birthDate;
        public DateTime BirthDate
        {
            get { return _birthDate; }
            set
            {
                if (value >= DateTime.Today)
                    throw new InvalidBirthDateException(value);
                _birthDate = value;
            }
        }
        public Client(string firstName, string lastName, DateTime birthDate) :base()
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
        }
        public Client(string firstName, string lastName, DateTime birthDate, int portfolioId)
            :this(firstName, lastName, birthDate)
        {
            PortfolioId = portfolioId;
        }
        public override void removeFromList()
        {
            base.removeFromList();
            if(_portfolioId != 0)
            {
                Portfolio portfolio = Portfolio.SavedItems.Find(p => p.Id == _portfolioId) as Portfolio;
                portfolio.removeFromList();
            }
        }
    }
}
