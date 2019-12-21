// (c) 2019 SharpCoding
// This code is licensed under MIT license (see LICENSE.txt for details)
using System;

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
    }
}
