using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpCoding.SharpHelpers;

namespace SharpHelpers.UnitTest.String
{
    [TestClass]
    public class StringTest
    {
        [TestMethod]
        public void TestReplace()
        {
            var instance = "This is a test method";
            var toReplace = new string[] { "test" };
            var replaceWith = "TEST";

            var result = instance.Replace(toReplace, replaceWith);
            Assert.IsNotNull(result);
            Assert.IsTrue(result == $"This is a {replaceWith} method");
        }
    }
}
