// (c) 2019 SharpCoding
// This code is licensed under MIT license (see LICENSE.txt for details)
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpCoding.SharpHelpers;

namespace SharpHelpers.UnitTest.Regex
{
    [TestClass]
    public class RegexTests
    {
        [TestMethod]
        public void IsMatch_ShouldReturnTrue_WhenPatternMatches()
        {
            // Arrange
            string input = "hello world";
            string pattern = @"hello";

            // Act
            bool result = input.IsMatchRegex(pattern);

            // Assert
            Assert.IsTrue(result, "Expected the pattern to match the input string.");
        }

        [TestMethod]
        public void IsMatch_ShouldReturnFalse_WhenPatternDoesNotMatch()
        {
            // Arrange
            string input = "hello world";
            string pattern = @"goodbye";

            // Act
            bool result = input.IsMatchRegex(pattern);

            // Assert
            Assert.IsFalse(result, "Expected the pattern not to match the input string.");
        }

        [TestMethod]
        public void Match_ShouldReturnFirstMatch_WhenPatternMatches()
        {
            // Arrange
            string input = "hello world";
            string pattern = @"hello";

            // Act
            string result = input.Match(pattern);

            // Assert
            Assert.AreEqual("hello", result, "Expected the first match to be 'hello'.");
        }

        [TestMethod]
        public void Match_ShouldReturnNull_WhenPatternDoesNotMatch()
        {
            // Arrange
            string input = "hello world";
            string pattern = @"goodbye";

            // Act
            string result = input.Match(pattern);

            // Assert
            Assert.IsNull(result, "Expected no match to be found.");
        }

        [TestMethod]
        public void Replace_ShouldReplaceAllOccurrences_WhenPatternMatches()
        {
            // Arrange
            string input = "hello world world";
            string pattern = @"world";
            string replacement = "universe";

            // Act
            string result = input.Replace(pattern, replacement);

            // Assert
            Assert.AreEqual("hello universe universe", result, "Expected 'world' to be replaced with 'universe'.");
        }

        [TestMethod]
        public void Split_ShouldReturnArray_WhenPatternIsUsedAsDelimiter()
        {
            // Arrange
            string input = "hello world universe";
            string pattern = @" ";

            // Act
            string[] result = input.Split(pattern);

            // Assert
            CollectionAssert.AreEqual(new[] { "hello", "world", "universe" }, result, "Expected the input string to be split by spaces.");
        }
    }
}
