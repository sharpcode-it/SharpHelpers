using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpCoding.SharpHelpers;

namespace SharpHelpers.UnitTest.Boolean
{
    [TestClass]
    public class BooleanTest
    {
        [TestMethod]
        public void TestAnd()
        {
            Assert.IsTrue(true.And(true));
            Assert.IsFalse(false.And(false));
            Assert.IsFalse(true.And(false));
            Assert.IsFalse(false.And(true));
        }

        [TestMethod]
        public void TestOr()
        {
            Assert.IsFalse(false.Or(false));
            Assert.IsTrue(true.Or(true));
            Assert.IsTrue(true.Or(false));
            Assert.IsTrue(false.Or(true));
        }

        [TestMethod]
        public void TestXor()
        {
            Assert.IsFalse(true.Xor(true));
            Assert.IsFalse(false.Xor(false));
            Assert.IsTrue(true.Xor(false));
            Assert.IsTrue(false.Xor(true));
        }
    }
}
