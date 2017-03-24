using System;

namespace AttributeReader.UnitTests.Stubs
{
    public class SampleAttribute : Attribute
    {
        public string SomeKey { get; set; }
        public int SomeId { get; set; }
    }
}
