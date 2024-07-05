using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAWProject.Entities
{
    public class Entity<T>
    {
        private static Dictionary<Type, List<Entity<T>>> _savedItems = new Dictionary<Type, List<Entity<T>>>();
        public static List<Entity<T>> SavedItems
        {
            get
            {
                if (!_savedItems.ContainsKey(typeof(T)))
                    _savedItems[typeof(T)] = new List<Entity<T>>();
                return _savedItems[typeof(T)];
            }
            set
            {
                _savedItems[typeof(T)] = value;
            }
        }
        private static Dictionary<Type, int> _ctr = new Dictionary<Type, int>();
        public static int CTR
        {
            get
            {
                if(!_ctr.ContainsKey(typeof(T)))
                    _ctr[typeof(T)] = default;
                return _ctr[typeof(T)];
            }
            set
            {
                _ctr[typeof(T)] = value;
            }
        }
        private int _id;
        public int Id
        {
            get { return _id; }
        }
        public Entity()
        {
            _id = ++CTR;
            SavedItems.Add(this);
        }
        public virtual void removeFromList()
        {
            SavedItems.Remove(this);
        }
    }
}
