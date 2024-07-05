using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAWProject.Entities
{
    public class Stock : Entity<Stock>
    {
        private string _name;
        public string Name
        {
           get { return _name; }
           set { _name = value.Trim(); }
        }
        private string _token;
        public string Token
        {
            get { return _token; }
            set
            {
                if (Stock.SavedItems.Any(stockEnt => ((stockEnt as Stock).Token == value.ToUpper()) && ((stockEnt as Stock) != this)))
                    throw new Utils.ValueNotUniqueException<string>(value.ToUpper());
                _token = value.ToUpper();
            }
        }
        public Stock(string name, string token) :base()
        {
            Name = name;
            Token = token;
        }
    }
}
