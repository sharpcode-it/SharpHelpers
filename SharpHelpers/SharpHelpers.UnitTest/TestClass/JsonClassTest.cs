// (c) 2019 SharpCoding
// This code is licensed under MIT license (see LICENSE.txt for details)
using System.Collections.Generic;

namespace SharpHelpers.UnitTest.TestClass
{
    class JsonClassTest
    {
        public class GlossDef
        {
            public string Para { get; set; }
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
            public string Title { get; set; }
            public GlossList GlossList { get; set; }
        }

        public class Glossary
        {
            public string Title { get; set; }
            public GlossDiv GlossDiv { get; set; }
        }

        public class RootObject
        {
            public Glossary Glossary { get; set; }
        }

    }
}
