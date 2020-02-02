// (c) 2019 SharpCoding
// This code is licensed under MIT license (see LICENSE.txt for details)
using System;
using System.Globalization;

namespace SharpCoding.SharpHelpers
{
    public static class DateTimeHelper
    {
        /// <summary>
        /// Add the specific weeks to DateTime
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="weeks"></param>
        /// <returns></returns>
        public static DateTime AddWeeks(this DateTime dateTime, int weeks)
        {
            return dateTime.AddDays(weeks * 7);
        }

        /// <summary>
        /// Return the 12:00:00 AM instance of a DateTime
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime AbsoluteStart(this DateTime dateTime)
        {
            return dateTime.Date;
        }

        /// <summary>
        /// Return the 11:59:59 PM instance of a DateTime
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime AbsoluteEnd(this DateTime dateTime)
        {
            return AbsoluteStart(dateTime).AddDays(1).AddTicks(-1);
        }

        /// <summary>
        /// Return the UTC value
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime? ToUniversalTime(this DateTime? dateTime)
        {
            return dateTime?.ToUniversalTime();
        }

        /// <summary>
        /// Return the start of the current day
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime GetStartOfDay(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 0, 0, 0, 0);
        }

        /// <summary>
        /// Return the end of the current day
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime GetEndOfDay(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month,
                                 dateTime.Day, 23, 59, 59, 999);
        }

        /// <summary>
        /// Try to parse the string value with specific DateTime formats
        /// </summary>
        /// <param name="value"></param>
        /// <param name="formats"></param>
        /// <returns></returns>
        public static DateTime? AsDateTime(this string value, string[] formats)
        {
            if (DateTime.TryParseExact(value, formats, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind,
                out DateTime utcDateTime))
            {
                return utcDateTime;
            }

            return null;
        }
    }
}
