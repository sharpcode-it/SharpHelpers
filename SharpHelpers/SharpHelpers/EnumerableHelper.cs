// (c) 2019 SharpCoding
// This code is licensed under MIT license (see LICENSE.txt for details)
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        /// <exception cref="System.ArgumentNullException">throw when <paramref name="list"/> is null</exception>
        /// <returns></returns>
        public static IEnumerable<T> DistinctBy<T>(this IEnumerable<T> enumerable, Func<T, object> propertySelector)
        {
            if (enumerable == null) throw new ArgumentNullException(nameof(enumerable));
            if (propertySelector == null) throw new ArgumentNullException(nameof(propertySelector));

            return enumerable
                 .GroupBy(propertySelector)
                 .Select(x => x.First());
        }

        /// <summary>
        /// This method returns a sublist of the instance after a distinctby
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static IEnumerable<T> DistinctBy<T>(this IEnumerable<T> enumerable)
        {
            if (enumerable == null) throw new ArgumentNullException(nameof(enumerable));

            return enumerable
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
        public static IEnumerable<T> GetDuplicates<T>(this IEnumerable<T> enumerable, Func<T, object> propertySelector)
        {
            if (enumerable == null) throw new ArgumentNullException(nameof(enumerable));
            if (propertySelector == null) throw new ArgumentNullException(nameof(propertySelector));

            var enumer = enumerable
                 .GroupBy(propertySelector)
                 .Where(k => k.Count() > 1)
                 .Select(g => (T)g.First());

            return enumer;

        }

        /// <summary>
        /// This method returns the duplicates object count on the specific property
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="propertySelector"></param>
        /// <returns></returns>
        public static int CountDuplicates<T>(this IEnumerable<T> enumerable, Func<T, object> propertySelector)
        {
            if (enumerable == null) throw new ArgumentNullException(nameof(enumerable));
            if (propertySelector == null) throw new ArgumentNullException(nameof(propertySelector));

            return enumerable
                .GroupBy(propertySelector).Where(k => k.Count() > 1)
                .Select(g => g.Count()).Sum();

        }

        /// <summary>
        /// Sets value at speciefied index
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="index"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool AddOrSet<T>(this IEnumerable<T> enumerable, int index, T value)
        {
            if (enumerable == null) throw new ArgumentNullException(nameof(enumerable));

            if ((enumerable as List<T>).Count < index) return false;
            if ((enumerable as List<T>).Count > index)
            {
                (enumerable as List<T>)[index] = value;
                return true;
            }
            (enumerable as List<T>).Add(value);

            return true;
        }

        /// <summary>
        /// This method checks if all the element of the list are serializable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static bool IsSerializable<T>(this IEnumerable<T> enumerable)
        {
            if (enumerable == null) throw new ArgumentNullException(nameof(enumerable));

            return enumerable.All(item => item.GetType().IsSerializable);
        }

        /// <summary>
        /// This method returns a string of items with delimiter
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="delimiter"></param>
        /// <returns></returns>
        public static string ToString<T>(this IEnumerable<T> enumerable, string delimiter)
        {
            if (enumerable == null) throw new ArgumentNullException(nameof(enumerable));

            return string.Join(delimiter, enumerable.ToArray());
        }

        /// <summary>
        /// This method splits the list into 'size' sublists
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static IEnumerable<List<T>> Split<T>(this IEnumerable<T> enumerable, int size)
        {
            if (enumerable == null) throw new ArgumentNullException(nameof(enumerable));
            if (size < 0) throw new ArgumentException(nameof(size));
            var list = enumerable.ToList();
            var splitList = new List<List<T>>();
            for (var i = 0; i < list.Count; i += size)
            {
                splitList.Add(list.GetRange(i, Math.Min(size, list.Count - i)));
            }
            return splitList;
        }

        /// <summary>
        /// This method returns the description as string of the enum that invokes the method
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetDescription(this Enum value)
        {
            var description = GetAttribute<DescriptionAttribute>(value);
            return description?.Description;
        }

        /// <summary>
        /// This method returns the specific attribute of type TAttribute of the Enum that invokes the method,
        /// </summary>
        /// <typeparam name="TAttribute"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static TAttribute GetAttribute<TAttribute>(this Enum value)
            where TAttribute : Attribute
        {

            var type = value.GetType();
            var name = Enum.GetName(type, value);
            return type.GetField(name)
                .GetCustomAttributes(false)
                .OfType<TAttribute>()
                .SingleOrDefault();
        }

        /// <summary>
        /// This method returns the default value of the specified TEnum
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns></returns>
        public static TEnum GetDefaultValue<TEnum>() where TEnum : struct
        {
            var t = typeof(TEnum);
            var attributes = (DefaultValueAttribute[])t.GetCustomAttributes(typeof(DefaultValueAttribute), false);
            if (attributes.Length > 0)
            {
                return (TEnum)attributes[0].Value;
            }
            return default;
        }

        /// <summary>
        /// this method returns the specified struct T from the string that invokes the method
        /// If the value is null or T is not an enum, the method returns the default value of the T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T GetEnumFromDescription<T>(this string value) where T : struct
        {
            var enumStringValue = string.Empty;
            var enumType = typeof(T);

            if ((!enumType.IsEnum) || string.IsNullOrEmpty(value))
                return default;

            foreach (var fieldInfo in enumType.GetFields())
            {
                //Get the StringValueAttribute for each enum member 
                if (fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute),
                    false) is DescriptionAttribute[] attribs && attribs.Length > 0)
                    enumStringValue = attribs[0].Description;

                if (string.Compare(enumStringValue, value, StringComparison.OrdinalIgnoreCase) == 0)
                    return (T)Enum.Parse(enumType, fieldInfo.Name);
            }
            return default;
        }

        /// <summary>
        /// Given  a string this method returns the parsed enum T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
    }
}
