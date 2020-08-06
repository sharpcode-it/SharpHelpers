// (c) 2019 SharpCoding
// This code is licensed under MIT license (see LICENSE.txt for details)
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpCoding.SharpHelpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SharpHelpers.UnitTest.Dictionary
{

    [TestClass]
    public class DictionaryTest
    {
        [TestMethod]
        public void TestAddFormat()
        {
            var dic = new Dictionary<int, DateTime>() { { 1, DateTime.Now }, { 2, DateTime.Now } };

        }
        [TestMethod]
        public void TestRemoveAll()
        {
            var dic = new Dictionary<int, DateTime>() { { 1, DateTime.Now }, { 2, DateTime.Now } };
            dic.RemoveAll(a => a.Key < 2);
            Assert.IsTrue(dic.Count() == 1);

        }
        [TestMethod]
        public void TestGetOrCreate()
        {
            var dic = new Dictionary<int, DateTime>() { { 1, DateTime.Now }, { 2, DateTime.Now } };
            Assert.IsNotNull(dic.GetOrCreate(1));
            Assert.IsNotNull(dic.GetOrCreate(3));


        }
    }

}
