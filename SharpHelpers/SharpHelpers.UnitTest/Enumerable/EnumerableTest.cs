using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpCoding.SharpHelpers;
using System.Collections.Generic;
using System.Linq;

namespace SharpHelpers.UnitTest.Enumerable
{
    [TestClass]
    public class EnumerableTest
    {
        [TestMethod]
        public void TestAddOrSet()
        {
            const int index = 0;
            var list = new List<int>();
            list.AddOrSet(index, 10);
            Assert.IsTrue(list.Count > 0);
            Assert.IsTrue(list[index] == 10);
        }

        [TestMethod]
        public void TestCountDuplicates()
        {
            var list = new List<int> {10, 5, 10, 6};
            var result = list.DistinctBy().ToList();
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count < list.Count);
        }

        [TestMethod]
        public void TestSplit()
        {
            var list = new List<int> { 10, 5, 10, 6 };
            var result = list.Split(2).ToList();
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count == 2);
        }

        [TestMethod]
        public void TestToString()
        {
            var list = new List<int> { 10, 5, 10, 6 };
            var result = list.ToString(",");
            Assert.IsNotNull(result);
        }
    }
}
