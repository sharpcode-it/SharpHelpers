// (c) 2020 SharpCoding
// This code is licensed under MIT license (see LICENSE.txt for details)
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpCoding.SharpHelpers;

namespace SharpHelpers.UnitTest.DataTable
{
    [TestClass]

    public class DataTableTest
    {
        [TestMethod]
        public void TestColumnsOrder()
        {
            var dt = new System.Data.DataTable();
            dt.Columns.Add("First", typeof(string));
            dt.Columns.Add("Second", typeof(string));

            var columnOrder = new string[] { "Second", "First" };

            dt.SetColumnsOrder(columnOrder);

            Assert.IsTrue(dt.Columns[0].ColumnName == columnOrder[0]);
            Assert.IsTrue(dt.Columns[1].ColumnName == columnOrder[1]);
        }
    }
}
