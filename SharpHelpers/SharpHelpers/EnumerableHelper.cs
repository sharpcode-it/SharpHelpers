using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpCoding.SharpHelpers
{
    public static class EnumerableHelper
    {
        /// <summary>
        /// This method returns a sublist of the instance after a distinctby operation
        /// </summary>
        /// <param name="list"></param>
        /// <param name="propertySelector"></param>
        /// <returns></returns>
        public static IEnumerable DistinctBy<T>(this List<T> list, Func<T, object> propertySelector)
        {
             return list.GroupBy(propertySelector).Select(x => x.First());
        }
    }
}
