// (c) 2023 SharpCoding
// This code is licensed under MIT license (see LICENSE.txt for details)using System;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;


namespace SharpCoding.SharpHelpers
{
    /// <summary>
    /// The DateTimeSmart class is a wrapper around the DateTime structure,
    /// providing additional functionality for cast-from-string operations.
    /// </summary>
    public class DateTimeSmart
    {
        private static string[] _formats = { "dd-MM-yyyy", "yyyy-MM-dd", "dd-MM-yyyy HH:mm:ss" };
        /// <summary>
        /// A private constructor that initializes a new instance of the DateTimeSmart class with a specified DateTime value
        /// </summary>
        /// <param name="dateTime"></param>
        private DateTimeSmart(DateTime dateTime)
        {
            DateTime = new DateTime(dateTime.Ticks, dateTime.Kind);
        }

        /// <summary>
        /// A private static field that serves as a lock to ensure thread safety when modifying the _formats field.
        /// </summary>
        private static readonly object _formatsLocker = new object();

        /// <summary>
        /// A private static method that checks if a string can be a format string for a DateTime object.
        /// </summary>
        /// <param name="format"></param>
        /// <remarks>
        /// Nice to have: find a way to validate any format strings regardless of localization and without using try parsing.
        /// </remarks>
        /// <returns></returns>
        private static bool IsValidDateTimeFormat(string format)
        {
            try
            {
                var dtIn = DateTime.Now.ToString(format);
                //  This is not a foolproof method.
                return string.Compare(dtIn, format, StringComparison.InvariantCultureIgnoreCase) != 0;
            }
            catch
            {
                return false;
            }
        }


        /// <summary>
        /// A public static method that adds new date formats that the class can handle.
        /// </summary>
        /// <param name="formats"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static bool AddFormats(params string[] formats)
        {
            if (formats == null || formats.Length == 0)
            {
                throw new ArgumentNullException(nameof(formats));
            }

            var extras = formats.Except(_formats).ToList();
            if (extras.TrueForAll(IsValidDateTimeFormat) == false)
            {
                throw new ArgumentException("Some string is not in the right format to parse a DateTime.", nameof(formats));
            }

            if (extras.Any())
            {
                lock (_formatsLocker)
                {
                    _formats = _formats.Concat(extras).ToArray();
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// A public static method that lists the date formats that the class currently can handle.
        /// </summary>
        public static IEnumerable<string> GetCurrentFormats() => _formats;

        /// <summary>
        /// A private property that gets or sets the internal DateTime value.
        /// </summary>
        private DateTime DateTime { get; set; }

        /// <summary>
        /// An explicit conversion operator that converts a string to a DateTimeSmart object.
        /// </summary>
        /// <param name="date"></param>
        public static explicit operator DateTimeSmart(string date)
        {
            DateTime.TryParseExact(date, _formats, CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal, out var dateTime);
            return new DateTimeSmart(dateTime);
        }

        /// <summary>
        /// An explicit conversion operator that converts a DateTime object to a DateTimeSmart object.
        /// </summary>
        /// <param name="dateTime"></param>
        public static explicit operator DateTimeSmart(DateTime dateTime)
        {
            var dt = dateTime.Kind != DateTimeKind.Unspecified ? dateTime : DateTime.SpecifyKind(dateTime, DateTimeKind.Local);
            return new DateTimeSmart(dt);
        }

        /// <summary>
        /// An implicit conversion operator that converts a DateTimeSmart object to a DateTime object.
        /// </summary>
        /// <param name="dummy"></param>
        public static implicit operator DateTime(DateTimeSmart dummy) => dummy.DateTime;

        /// <summary>
        /// An override of the ToString method that returns the string representation of the DateTime object
        /// in the "yyyy-MM-dd HH:mm:ss.fff" format.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => this.ToString("yyyy-MM-dd HH:mm:ss.fff");

        /// <summary>
        /// Overloads of the ToString method that return the string representation of the DateTime object in a specified format
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        public string ToString(string format) => DateTime.ToString(format);

        /// <summary>
        /// Overloads of the ToString method that return the string representation of the DateTime object in a specified format and with a specified format provider.
        /// </summary>
        /// <param name="format"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        public string ToString(string format, IFormatProvider provider) => DateTime.ToString(format, provider);

        /// <summary>
        /// Overloads of the ToString method that return the string representation of the DateTime object in a specified format provider.
        /// </summary>
        /// <param name="provider"></param>
        /// <returns></returns>
        public string ToString(IFormatProvider provider) => DateTime.ToString(provider);
    }
}
