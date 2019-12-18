// (c) 2019 SharpCoding
// This code is licensed under MIT license (see LICENSE.txt for details)
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpCoding.SharpHelpers;
using System;
using static SharpHelpers.UnitTest.TestClass.JsonClassTest;

namespace SharpHelpers.UnitTest.String
{
    [TestClass]
    public class ObjectTest
    {
        [TestMethod]
        public void TestIsSystemType()
        {
            var guid = new Guid();
        
            Assert.IsTrue(guid.GetType().IsSystemType());
         
            var glossary = new Glossary();
        
            Assert.IsFalse(glossary.GetType().IsSystemType());

        }


    }
}
