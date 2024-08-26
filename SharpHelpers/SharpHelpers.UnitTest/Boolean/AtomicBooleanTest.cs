// (c) 2023 SharpCoding
// This code is licensed under MIT license (see LICENSE.txt for details)using System;

using System.Runtime.InteropServices.ComTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpCoding.SharpHelpers;

namespace SharpHelpers.UnitTest.Boolean
{
    [TestClass]
    public class AtomicBooleanTest
    {
        [TestMethod]
        public void TestBool()
        {
            var ab1 = new AtomicBoolean();

            var result = ab1 == true;
            Assert.IsFalse(result);

            ab1 = true;
            result = ab1 == false;
            Assert.IsFalse(result);

            result = ab1 == true;
            Assert.IsTrue(result);

            ab1 = false;
            result = true == ab1;
            Assert.IsFalse(result);

            var ab2 = new AtomicBoolean();

            result = ab2 == ab1;
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void TestAnd()
        {
            var t = new AtomicBoolean(true);
            var f = new AtomicBoolean(false);

            Assert.IsTrue(t.And(t));
            Assert.IsFalse(f.And(f));
            Assert.IsFalse(t.And(f));
            Assert.IsFalse(f.And(t));
        }

        [TestMethod]
        public void TestOr()
        {
            var t = new AtomicBoolean(true);
            var f = new AtomicBoolean(false);

            Assert.IsFalse(f.Or(f));
            Assert.IsTrue(t.Or(t));
            Assert.IsTrue(t.Or(f));
            Assert.IsTrue(f.Or(t));
        }

        [TestMethod]
        public void TestXor()
        {
            var t = new AtomicBoolean(true);
            var f = new AtomicBoolean(false);

            Assert.IsFalse(t.Xor(t));
            Assert.IsFalse(f.Xor(f));
            Assert.IsTrue(t.Xor(f));
            Assert.IsTrue(f.Xor(t));
        }
    }
}
