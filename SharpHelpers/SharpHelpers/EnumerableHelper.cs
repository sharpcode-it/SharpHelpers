
// (c) 2019 SharpCoding
// This code is licensed under MIT license (see LICENSE.txt for details)using System;
using System.Collections.Generic;
using System.Linq;

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
        public static IEnumerable<T> DistinctBy<T>(this List<T> list, Func<T, object> propertySelector)
        {
            if (propertySelector == null) throw new ArgumentNullException(nameof(propertySelector));
            return list
                 .GroupBy(propertySelector)
                 .Select(x => x.First());
        }

        /// <summary>
        /// This method returns a sublist of the instance after a distinctby
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static IEnumerable<T> DistinctBy<T>(this List<T> list)
        {
            return list
                .GroupBy(x => x)
                .Select(x => x.First());
        }

        /// <summary>
        /// This method returns a list with duplicates counters
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="propertySelector"></param>
        /// <returns></returns>
        public static IEnumerable<T> GetDuplicates<T>(this List<T> list, Func<T, object> propertySelector)
        {
            if (propertySelector == null) throw new ArgumentNullException(nameof(propertySelector));
            return (IEnumerable<T>) list
                .GroupBy(propertySelector)
                .Select(g => new { Value = g.Key, Count = g.Count() })
                .OrderByDescending(x => x.Count);
        }

        /// <summary>
        /// This method returns the duplicates object count on the specific property
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="propertySelector"></param>
        /// <returns></returns>
        public static int CountDuplicates<T>(this List<T> list, Func<T, object> propertySelector)
        {
            if (propertySelector == null) throw new ArgumentNullException(nameof(propertySelector));
            return list
                .GroupBy(propertySelector)
                .Select(g => new { Value = g.Key, Count = g.Count() })
                .OrderByDescending(x => x.Count)
                .Count();
        }

        /// <summary>
        /// Sets value at speciefied index
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="index"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool AddOrSet<T>(this List<T> list, int index, T value)
        {
            if (list == null) throw new ArgumentNullException(nameof(list));
            if (list.Count < index) return false;
            if (list.Count > index)
            {
                list[index] = value;
                return true;
            }
            list.Add(value);
            return true;
        }

        /// <summary>
        /// This method checks if all the element of the list are serializable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static bool IsSerializable<T>(this List<T> list)
        {
            return list != null && list.All(item => item.GetType().IsSerializable);
        }

        /// <summary>
        /// This method returns a string of items with delimiter
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="delimiter"></param>
        /// <returns></returns>
        public static string ToString<T>(this List<T> list, string delimiter)
        {
            return string.Join(delimiter, list.ToArray());
        }

        /// <summary>
        /// This method splits the list into 'size' sublists
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static IEnumerable<List<T>> Split<T>(this List<T> list, int size)
        {
            if (list == null) throw new ArgumentNullException(nameof(list));
            if (size < 0) throw new ArgumentNullException(nameof(size));
            var splitList = new List<List<T>>();
            for (var i = 0; i < list.Count; i += size)
            {
                splitList.Add(list.GetRange(i, Math.Min(size, list.Count - i)));
            }
            return splitList;
        }
    }
}
