using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpCoding.SharpHelpers;

namespace SharpHelpers.UnitTest.Numeric
{
    // (c) 2019 SharpCoding
    // This code is licensed under MIT license (see LICENSE.txt for details)
    [TestClass]
    public class NumericTest
    {
        [TestMethod]
        public void TestIsOdd()
        {
            Assert.IsFalse(2.IsOdd());
            Assert.IsTrue(3.IsOdd());
        }

        [TestMethod]
        public void TestIsEven()
        {
            Assert.IsTrue(2.IsEven());
            Assert.IsFalse(3.IsEven());
        }
    }
}
