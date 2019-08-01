using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpCoding.SharpHelpers;

namespace SharpHelpers.UnitTest.Byte
{
    [TestClass]
    public class ByteTest
    {
        [TestMethod]
        public void TestToObject()
        {
            var byteArray = "This is a test method".ToByteArray();
            var obj = byteArray.ToObject();

            Assert.IsNotNull(obj);
            Assert.IsTrue("This is a test method" == obj.ToString());
        }

        [TestMethod]
        public void TestToByteArray()
        {
            var obj = "This is a test method";
            var byteArray = obj.ToByteArray();

            Assert.IsNotNull(byteArray);

            var str = byteArray.ToObject();

            Assert.IsNotNull(str);

            Assert.IsTrue(obj == (string) str);
        }
    }
}
