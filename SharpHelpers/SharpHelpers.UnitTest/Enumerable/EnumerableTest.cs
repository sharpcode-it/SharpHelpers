// (c) 2019 SharpCoding
// This code is licensed under MIT license (see LICENSE.txt for details)
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpCoding.SharpHelpers;
using System;
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
        public void TestDistinctBy()
        {
            var list = new List<int> {10, 5, 10, 6};
            var result = list.DistinctBy().ToList();
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count < list.Count);
        }
 
        [TestMethod]
        public void TestDistinctByPropertySelector()
        {
            var l1 = new List<int>() { 10 };
            var l2 = new List<int>() { 5, 5 };
            var l3 = new List<int>() { 10, 11 };
            var l4 = new List<int>() { 6, 5, 5 };

            var list = new List<List<int>>(){l1 ,l2 ,l3 ,l4 };
           
            var result = list.DistinctBy(p => p.Count).ToList();
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
      
       [TestMethod]
        public void TestIsSerializable()
        {
            var list = new List<int> { 10, 5, 10, 6 };
            var result = list.IsSerializable();
            Assert.IsTrue(result);

            var listN = new List<NonSerializableObj> { new NonSerializableObj("NonSerObje") };
            var resultN = listN.IsSerializable();
            Assert.IsFalse(resultN);

        }

        [TestMethod]
        public void TestGetDuplicates()
        {

            var list = new List<int> { 10, 5, 10, 6 };
            var result = list.GetDuplicates(a => a) ;
            Assert.IsTrue(result.Count() == 1);
            Assert.IsTrue(result.ToList()[0] == 10);

            var listN = new List<NonSerializableObj> { new NonSerializableObj("Obj1"), new NonSerializableObj("Obj3"), new NonSerializableObj("Obj2"), new NonSerializableObj("Obj2") };
            var resultN = listN.GetDuplicates(a => a.Name);
            Assert.IsTrue(resultN.Count() == 1);
            Assert.AreEqual("Obj2",resultN.ToList()[0].Name);
        }

        [TestMethod]
        public void TestCountDuplicates()
        {

            var list = new List<int> { 10, 5, 10, 6 };
            var result = list.CountDuplicates(a => a);
            Assert.IsTrue(result == 2);

            var listN = new List<NonSerializableObj> { new NonSerializableObj("Obj1"), new NonSerializableObj("Obj3"), new NonSerializableObj("Obj2"), new NonSerializableObj("Obj2") };
            var resultN = listN.CountDuplicates(a => a.Name);
            Assert.IsTrue(resultN == 2);
        }


    }


    public class NonSerializableObj
    {
      
        public string Name { get; set; }
        
         public NonSerializableObj(string name)
        {
            this.Name = name;
        }
    }
}
