using AttributeReader.UnitTests.Stubs;
using Xunit;

namespace AttributeReader.UnitTests
{
    public class ClassAttributeTests
    {
        [Fact]
        public void AttributeValueOrDefault_WithoutAttributeOnClass_ReturnsSpecifiedDefault()
        {
            var attribValue = new TestClassWithoutAttribute().AttributePropertyValueOrDefault<TestClassWithoutAttribute, SampleAttribute, int>(p => p.SomeId, 17);

            Assert.Equal(17, attribValue);
        }

        [Fact]
        public void AttributeValueOrDefault_WithoutAttributeOnClass_WithoutDefaultSpecified_ReturnsDefaultForType()
        {
            var attribValue = new TestClassWithoutAttribute().AttributePropertyValueOrDefault<TestClassWithoutAttribute, SampleAttribute, int>(p => p.SomeId);

            Assert.Equal(default(int), attribValue);
        }

        [Fact]
        public void AttributeValueOrDefault_WithAttributeOnClass_ReturnsValueFromAttributeProperty()
        {
            var idValue = new TestClassWithAttribute().AttributePropertyValueOrDefault<TestClassWithAttribute, SampleAttribute, int>(p => p.SomeId);
            var keyValue = new TestClassWithAttribute().AttributePropertyValueOrDefault<TestClassWithAttribute, SampleAttribute, string>(p => p.SomeKey);

            Assert.Equal(12, idValue);
            Assert.Equal("TheKey", keyValue);
        }

        [Sample(SomeId = 12, SomeKey = "TheKey")]
        internal class TestClassWithAttribute
        {

        }

        internal class TestClassWithoutAttribute
        {
            
        }
    }
}