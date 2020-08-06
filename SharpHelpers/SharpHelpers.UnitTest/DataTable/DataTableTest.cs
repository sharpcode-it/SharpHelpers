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

        [TestMethod]
        public void TestToList()
        {
            var dt = new System.Data.DataTable();
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Age", typeof(int));

            var row = dt.NewRow();
            row[0] = "Alice";
            row[1] = 20;

            var row2 = dt.NewRow();
            row2[0] = "Bob";
            row2[1] = 30;

            dt.Rows.Add(row);
            dt.Rows.Add(row2);

            var list = dt.ToList<TestClass>();

            Assert.IsNotNull(list);
            Assert.IsTrue(list.Count == 2);
        }
    }

    internal class TestClass
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
