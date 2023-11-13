// (c) 2023 SharpCoding
// This code is licensed under MIT license (see LICENSE.txt for details)

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpCoding.SharpHelpers;
using System.Linq;


namespace SharpHelpers.UnitTest.DateAndTime
{


    [TestClass]
    public class DateTimeTest
    {
        [TestMethod]
        public void TestDateTimeSmart()
        {
            var dtDictionary = new System.Collections.Generic.Dictionary<string, string>()
                    {
                        {"M/dd/yyyy hh:mm", "10/11/2023 09:00"},
                        {"MM/dd/yyyy hh:mm:ss tt zzz", "05/01/2009 01:30:42 PM -05:00"},
                        {"g", "10/11/2023 09:00"}
                    };

            DateTimeSmart.AddFormats(dtDictionary.Keys.ToArray());

            foreach (var key in dtDictionary.Keys)
            {
                DateTime dt = (DateTimeSmart)dtDictionary[key];
                Assert.IsFalse(dt == DateTime.MinValue);
            }

            DateTime dt1 = (DateTimeSmart)"01-05-2023 22:30:55";
            Assert.IsTrue(dt1 == new DateTime( 2023, 5, 1, 22, 30, 55, DateTimeKind.Local));

        }

    }
}
