using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpCoding.SharpHelpers;
using System.Collections.Generic;

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



        [TestMethod]
        public void TestLastAfter()
        {
            var instance = "This is a test, method.The final,method,OK!!!";
            var resultOK = "OK!!!";

            var result = instance.LastAfter(',');
            Assert.IsNotNull(result);
            Assert.IsTrue(result == $"{resultOK}");
        }

        [TestMethod]
        public void TestIsDBEqual()
        {
            var instance = "AbCde";
            var resultOK = "abcDE";

            var result = instance.IsDBEqual(resultOK);
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void TestIsNotDBEqual()
        {
            var instance = "AbCde";
            var resultOK = "abcE";

            var result = instance.IsNotDBEqual(resultOK);
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void TestIsInDB()
        {
            var instance = "AbCde";
            var resultOK = new string[] { "abcE", "ABCDe", "AbCdeF" };

            var result = instance.IsInDB(resultOK);
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void TestSafeSubstringByLength()
        {
            var instance = "AbCdeFgHiLmnO";
            var resultOK = "AbCdeFgHiL";

            var result = instance.SafeSubstringByLength(10);
            Assert.IsNotNull(result);
            Assert.IsTrue(result == $"{resultOK}");

        }

        [TestMethod]
        public void TestTruncate()
        {
            var instance = "AbCdeFgHiLmnO";
            var resultOK = "AbCdeFgHiL";
            bool outcome = false;

            var result = instance.Truncate(10, out outcome);
            Assert.IsNotNull(result);
            Assert.IsTrue(result == $"{resultOK}");
            Assert.IsTrue(outcome);

        }

        [TestMethod]
        public void TestToNullableInt()
        {
            var instance = "22";
            int resultOK = 22;

            var result = instance.ToNullableInt();
            Assert.IsNotNull(result);
            Assert.IsTrue(result == resultOK);

        }

        [TestMethod]
        public void TestToBase64()
        {
            var instance = "Man is distinguished, not only by his reason, but by this singular passion from other animals, which is a lust of the mind, that by a perseverance of delight in the continued and indefatigable generation of knowledge, exceeds the short vehemence of any carnal pleasure.";
            var resultOK = "TWFuIGlzIGRpc3Rpbmd1aXNoZWQsIG5vdCBvbmx5IGJ5IGhpcyByZWFzb24sIGJ1dCBieSB0aGlzIHNpbmd1bGFyIHBhc3Npb24gZnJvbSBvdGhlciBhbmltYWxzLCB3aGljaCBpcyBhIGx1c3Qgb2YgdGhlIG1pbmQsIHRoYXQgYnkgYSBwZXJzZXZlcmFuY2Ugb2YgZGVsaWdodCBpbiB0aGUgY29udGludWVkIGFuZCBpbmRlZmF0aWdhYmxlIGdlbmVyYXRpb24gb2Yga25vd2xlZGdlLCBleGNlZWRzIHRoZSBzaG9ydCB2ZWhlbWVuY2Ugb2YgYW55IGNhcm5hbCBwbGVhc3VyZS4=";
            var result = instance.ToBase64();
            Assert.IsNotNull(result);
            Assert.IsTrue(result == resultOK);

        }

        [TestMethod]
        public void TestFromBase64()
        {
            var instance = "TWFuIGlzIGRpc3Rpbmd1aXNoZWQsIG5vdCBvbmx5IGJ5IGhpcyByZWFzb24sIGJ1dCBieSB0aGlzIHNpbmd1bGFyIHBhc3Npb24gZnJvbSBvdGhlciBhbmltYWxzLCB3aGljaCBpcyBhIGx1c3Qgb2YgdGhlIG1pbmQsIHRoYXQgYnkgYSBwZXJzZXZlcmFuY2Ugb2YgZGVsaWdodCBpbiB0aGUgY29udGludWVkIGFuZCBpbmRlZmF0aWdhYmxlIGdlbmVyYXRpb24gb2Yga25vd2xlZGdlLCBleGNlZWRzIHRoZSBzaG9ydCB2ZWhlbWVuY2Ugb2YgYW55IGNhcm5hbCBwbGVhc3VyZS4=";
            var resultOK = "Man is distinguished, not only by his reason, but by this singular passion from other animals, which is a lust of the mind, that by a perseverance of delight in the continued and indefatigable generation of knowledge, exceeds the short vehemence of any carnal pleasure.";

            var result = instance.FromBase64();
            Assert.IsNotNull(result);
            Assert.IsTrue(result == resultOK);

        }

        [TestMethod]
        public void TestLeft()
        {
            var instance = "AbCdeFgHiLmnO";
            var resultOK = "AbCde";

            var result = instance.Left(5);
            Assert.IsNotNull(result);
            Assert.IsTrue(result == $"{resultOK}");

        }

        [TestMethod]
        public void TestRigth()
        {
            var instance = "AbCdeFgHiLmnO";
            var resultOK = "iLmnO";

            var result = instance.Right(5);
            Assert.IsNotNull(result);
            Assert.IsTrue(result == $"{resultOK}");

        }

        [TestMethod]
        public void TestJsonToObject()
        {
            var instance = "{\"glossary\": {\"title\": \"example glossary\",\"GlossDiv\": {\"title\": \"S\",\"GlossList\": { \"GlossEntry\": {\"ID\": \"SGML\",\"SortAs\": \"SGML\",\"GlossTerm\": \"Standard Generalized Markup Language\",\"Acronym\": \"SGML\",\"Abbrev\": \"ISO 8879:1986\",\"GlossDef\": {\"para\": \"A meta-markup language, used to create markup languages such as DocBook.\",\"GlossSeeAlso\": [\"GML\", \"XML\"]},\"GlossSee\": \"markup\"}}}}}";
           
            var result = instance.JsonToObject<RootObject>();
            Assert.IsNotNull(result);
          
        }

  
        





        
        
        
        
        
        
        
        
        
        
        
        #region Json Class
        public class GlossDef
        {
            public string para { get; set; }
            public List<string> GlossSeeAlso { get; set; }
        }

        public class GlossEntry
        {
            public string ID { get; set; }
            public string SortAs { get; set; }
            public string GlossTerm { get; set; }
            public string Acronym { get; set; }
            public string Abbrev { get; set; }
            public GlossDef GlossDef { get; set; }
            public string GlossSee { get; set; }
        }

        public class GlossList
        {
            public GlossEntry GlossEntry { get; set; }
        }

        public class GlossDiv
        {
            public string title { get; set; }
            public GlossList GlossList { get; set; }
        }

        public class Glossary
        {
            public string title { get; set; }
            public GlossDiv GlossDiv { get; set; }
        }

        public class RootObject
        {
            public Glossary glossary { get; set; }
        }
        #endregion

    }
}
