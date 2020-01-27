using System;

namespace SharpHelpers.UnitTest.Mock
{
    public class Foo
    {
        public Guid Id { get; set; }
        public string Prop1 { get; set; }

        public DateTime Prop2 { get; set; }
    }

    public class Foo2
    {
        public Guid Id { get; set; }
        public string Prop1 { get; set; }

        public DateTime Prop2 { get; set; }

        public Foo FooItem { get; set; }
    }
}
