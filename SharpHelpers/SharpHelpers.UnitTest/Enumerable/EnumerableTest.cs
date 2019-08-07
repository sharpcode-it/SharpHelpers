﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpCoding.SharpHelpers;
using System.Collections.Generic;
using System.Linq;

namespace SharpHelpers.UnitTest.Enumerable
{
    /*
     * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
     * "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
     * LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR
     * A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT
     * OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL,
     * SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT
     * LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
     * DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY
     * THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
     * (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
     * OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
     *
     * This software consists of voluntary contributions made by many individuals
     * and is licensed under the MIT license. For more information, see
     * <http://www.doctrine-project.org>.
     */
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
        public void TestCountDuplicates()
        {
            var list = new List<int> {10, 5, 10, 6};
            var result = list.DistinctBy().ToList();
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
    }
}
