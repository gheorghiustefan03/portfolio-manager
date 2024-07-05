using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAWProject.Entities
{
    public class Utils
    {
        internal class ValueNotUniqueException<T> : Exception
        {
            private T _value;
            public ValueNotUniqueException(T value)
            {
                _value = value;
            }
            public override string Message
            {
                get
                {
                    return "Value " + _value.ToString() + " not unique";
                }
            }

        }
        public static bool isEmptyStr(string str)
        {
            return string.IsNullOrEmpty(str.Trim());
        }
    }
}
