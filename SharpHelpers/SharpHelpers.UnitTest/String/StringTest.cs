// (c) 2019 SharpCoding
// This code is licensed under MIT license (see LICENSE.txt for details)

using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpCoding.SharpHelpers;
using SharpCoding.SharpHelpers.DomainModel;
using System.Globalization;
using static SharpHelpers.UnitTest.TestClass.JsonClassTest;

namespace SharpHelpers.UnitTest.String
{
    [TestClass]
    public class StringTest
    {
        [TestMethod]
        public void TestReplace()
        {
            const string instance = "This is a test method";
            var toReplace = new[] { "test" };
            const string replaceWith = "TEST";

            var result = instance.Replace(toReplace, replaceWith);
            Assert.IsNotNull(result);
            Assert.IsTrue(result == $"This is a {replaceWith} method");
        }

        [TestMethod]
        public void TestLastAfter()
        {
            const string instance = "This is a test, method.The final,method,OK!!!";
            const string resultOk = "OK!!!";

            var result = instance.LastAfter(',');
            Assert.IsNotNull(result);
            Assert.IsTrue(result == $"{resultOk}");
        }

        [TestMethod]
        public void TestIsDbEqual()
        {
            const string instance = "AbCde";
            const string resultOk = "abcDE";

            var result = instance.IsDbEqual(resultOk);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestIsNotDbEqual()
        {
            const string instance = "AbCde";
            const string resultOk = "abcE";

            var result = instance.IsNotDbEqual(resultOk);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestIsInDb()
        {
            const string instance = "AbCde";
            var resultOk = new[] { "abcE", "ABCDe", "AbCdeF" };

            var result = instance.IsInDb(resultOk);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestSafeSubstringByLength()
        {
            const string instance = "AbCdeFgHiLmnO";
            const string resultOk = "AbCdeFgHiL";

            var result = instance.SafeSubstringByLength(10);
            Assert.IsNotNull(result);
            Assert.IsTrue(result == $"{resultOk}");
        }

        [TestMethod]
        public void TestTruncate()
        {
            const string instance = "AbCdeFgHiLmnO";
            const string resultOk = "AbCdeFgHiL";

            var result = instance.Truncate(10, out var outcome);
            Assert.IsNotNull(result);
            Assert.IsTrue(result == $"{resultOk}");
            Assert.IsTrue(outcome);
        }

        [TestMethod]
        public void TestToNullableInt()
        {
            const string instance = "22";
            const int resultOk = 22;

            var result = instance.ToNullableInt();
            Assert.IsNotNull(result);
            Assert.IsTrue(result == resultOk);
        }

        [TestMethod]
        public void TestToBase64()
        {
            const string instance = "Man is distinguished, not only by his reason, but by this singular passion from other animals, which is a lust of the mind, that by a perseverance of delight in the continued and indefatigable generation of knowledge, exceeds the short vehemence of any carnal pleasure.";
            const string resultOk = "TWFuIGlzIGRpc3Rpbmd1aXNoZWQsIG5vdCBvbmx5IGJ5IGhpcyByZWFzb24sIGJ1dCBieSB0aGlzIHNpbmd1bGFyIHBhc3Npb24gZnJvbSBvdGhlciBhbmltYWxzLCB3aGljaCBpcyBhIGx1c3Qgb2YgdGhlIG1pbmQsIHRoYXQgYnkgYSBwZXJzZXZlcmFuY2Ugb2YgZGVsaWdodCBpbiB0aGUgY29udGludWVkIGFuZCBpbmRlZmF0aWdhYmxlIGdlbmVyYXRpb24gb2Yga25vd2xlZGdlLCBleGNlZWRzIHRoZSBzaG9ydCB2ZWhlbWVuY2Ugb2YgYW55IGNhcm5hbCBwbGVhc3VyZS4=";

            var result = instance.ToBase64();
            Assert.IsNotNull(result);
            Assert.IsTrue(result == resultOk);
        }

        [TestMethod]
        public void TestFromBase64()
        {
            const string instance = "TWFuIGlzIGRpc3Rpbmd1aXNoZWQsIG5vdCBvbmx5IGJ5IGhpcyByZWFzb24sIGJ1dCBieSB0aGlzIHNpbmd1bGFyIHBhc3Npb24gZnJvbSBvdGhlciBhbmltYWxzLCB3aGljaCBpcyBhIGx1c3Qgb2YgdGhlIG1pbmQsIHRoYXQgYnkgYSBwZXJzZXZlcmFuY2Ugb2YgZGVsaWdodCBpbiB0aGUgY29udGludWVkIGFuZCBpbmRlZmF0aWdhYmxlIGdlbmVyYXRpb24gb2Yga25vd2xlZGdlLCBleGNlZWRzIHRoZSBzaG9ydCB2ZWhlbWVuY2Ugb2YgYW55IGNhcm5hbCBwbGVhc3VyZS4=";
            const string resultOk = "Man is distinguished, not only by his reason, but by this singular passion from other animals, which is a lust of the mind, that by a perseverance of delight in the continued and indefatigable generation of knowledge, exceeds the short vehemence of any carnal pleasure.";

            var result = instance.FromBase64();
            Assert.IsNotNull(result);
            Assert.IsTrue(result == resultOk);
        }

        [TestMethod]
        public void TestLeft()
        {
            const string instance = "AbCdeFgHiLmnO";
            const string resultOk = "AbCde";

            var result = instance.Left(5);
            Assert.IsNotNull(result);
            Assert.IsTrue(result == $"{resultOk}");
        }

        [TestMethod]
        public void TestRight()
        {
            const string instance = "AbCdeFgHiLmnO";
            const string resultOk = "iLmnO";

            var result = instance.Right(5);
            Assert.IsNotNull(result);
            Assert.IsTrue(result == $"{resultOk}");
        }

        [TestMethod]
        public void TestJsonToObject()
        {
            const string instance = "{\"glossary\": {\"title\": \"example glossary\",\"GlossDiv\": {\"title\": \"S\",\"GlossList\": { \"GlossEntry\": {\"ID\": \"SGML\",\"SortAs\": \"SGML\",\"GlossTerm\": \"Standard Generalized Markup Language\",\"Acronym\": \"SGML\",\"Abbrev\": \"ISO 8879:1986\",\"GlossDef\": {\"para\": \"A meta-markup language, used to create markup languages such as DocBook.\",\"GlossSeeAlso\": [\"GML\", \"XML\"]},\"GlossSee\": \"markup\"}}}}}";

            var result = instance.JsonToObject<RootObject>();
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestIsEmail()
        {
            const string instance = "name_surname@email.com";

            var result = instance.IsEmail();
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void TestIsNumber()
        {
            const string instance = "11.2";

            var result = instance.IsNumber();
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void TestIsGuid()
        {
            const string instance = "066aecf6-8608-4b46-80e6-275a05595ad6";

            var result = instance.IsGuid();
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void TestWordCount()
        {
            const string instance = "Man is distinguished, not only by his reason, but by this singular passion " +
                                    "from other animals, which is a lust of the mind, that by a perseverance of delight" +
                                    " in the continued and indefatigable generation of knowledge, exceeds the short " +
                                    "vehemence of any carnal pleasure.";

            var result = instance.WordCount("generation");
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void TestFiscalCode()
        {
            const string instance = "MRARSS02A05L219I";

            var result = instance.IsValidFiscalCode();
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void TestValidIban()
        {
            var instance = "DE89370400440532013000";

            var result = instance.IsValidIban();
            Assert.AreEqual(true, result);
            instance = "IT60X0542811101000000123456";
            result = instance.IsValidIban();
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void TestValidUrl()
        {
            const string instance = "https://www.google.com/";

            var result = instance.IsValidUrl();
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void TestFormatWithMask()
        {
            var s = "aaaaaaaabbbbccccddddeeeeeeeeeeee".FormatWithMask("Hello ########-#A###-####-####-############ Oww");
            Assert.AreEqual(true, s == "Hello aaaaaaaa-bAbbb-cccc-dddd-eeeeeeeeeeee Oww");
        }

        [TestMethod]
        public void TestCleanText()
        {
            const string istance = @"<!DOCTYPE html><html lang=""it"">
            <head>
            <title>CSS Template</title>
            <meta charset=""utf-8"">
            <meta name=""viewport"" content=""width=device-width, initial-scale=1"">
            </head>
            <body>
            <h2>Lorem ipsum</h2>
            <p>Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsumLorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum.</p>
            <header>
              <h2>Cities</h2>
            </header>
            <section>
              <nav>
                <ul>
                  <li><a href=""#"">Lorem ipsum</a></li>
                  <li><a href=""#"">Lorem ipsum#2</a></li>
                  <li><a href=""#"">Lorem ipsum#3</a></li>
                </ul>
              </nav>
              <article>
                <h1>Lorem ipsum</h1>
                <p>Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum Lorem ipsum</p>
              </article>
            </section>
            <footer>
              <p>Footer</p>
            </footer>
            </body>";

            var cleanedText = istance.CleanText(CleanTextMode.AllHtmlTags);


        }

        [TestMethod]
        public void TestToInt32()
        {
            var testInput = "17";

            Assert.IsTrue(testInput.ToInt32() == 17);

            testInput = "-17";
            Assert.IsTrue(testInput.ToInt32() == -17);

            testInput = "€17";
            Assert.IsTrue(testInput.ToInt32(new CultureInfo("it-IT")) == 17);

            testInput = "1.700";
            Assert.IsTrue(testInput.ToInt32(new CultureInfo("it-IT")) == 1700);

            //Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            testInput = "$17";
            Assert.IsTrue(testInput.ToInt32(new CultureInfo("en-US")) == 17);

            testInput = "1,700";
            Assert.IsTrue(testInput.ToInt32(new CultureInfo("en-US")) == 1700);
        }
    }
}
