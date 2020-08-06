// (c) 2019 SharpCoding
// This code is licensed under MIT license (see LICENSE.txt for details)
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpCoding.SharpHelpers;
using SharpCoding.SharpHelpers.ObjectExtensions;
using SharpHelpers.UnitTest.Mock;
using System;
using System.Collections.Generic;
using static SharpHelpers.UnitTest.TestClass.JsonClassTest;

namespace SharpHelpers.UnitTest.Object
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

        [TestMethod]
        public void TestClone()
        {
            var foo1 = new Foo()
            {
                Id = Guid.NewGuid(),
                Prop1 = "TEST_EQUALITY",
                Prop2 = DateTime.Now
            };

            var foo2 = foo1.Clone<Foo>();

            var f1Str = foo1.SerializeToJson();
            var f2Str = foo2.SerializeToJson();

            Assert.IsTrue(f1Str == f2Str);

            var foo21 = new Foo2
            {
                Id = Guid.NewGuid(),
                Prop1 = "TEST_EQUALITY#2",
                Prop2 = DateTime.Now,
                FooItem = foo1
            };

            var foo22 = foo21.Clone<Foo2>();

            var f11Str = foo21.SerializeToJson();
            var f22Str = foo22.SerializeToJson();

            Assert.IsTrue(f11Str == f22Str);

            var foo31 = new Foo2()
            {
                Id = Guid.NewGuid(),
                Prop1 = "TEST_EQUALITY#3",
                Prop2 = DateTime.Now,
                FooItem = foo1
            };

            var foo32 = foo31.Clone<Foo2>(new List<string> { "Prop1" });

            var f31Str = foo31.SerializeToJson();
            var f32Str = foo32.SerializeToJson();

            Assert.IsTrue(f31Str != f32Str);
            Assert.IsTrue(string.IsNullOrEmpty(foo32.Prop1) && string.IsNullOrEmpty(foo32.FooItem.Prop1));
        }

    }
}
