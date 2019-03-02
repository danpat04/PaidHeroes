using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PaidHeroes.Core
{
    public class EnumUtil<T> where T : struct, IConvertible
    {
        private static IEnumerable<T> _enumerable = null;
        public static IEnumerable<T> Iterate()
        {
            if (_enumerable == null)
            {
                _enumerable = Enum.GetValues(typeof(T)).Cast<T>();
            }
            return _enumerable;
        }
    }
}
