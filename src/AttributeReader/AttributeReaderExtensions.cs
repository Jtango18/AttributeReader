using System;
using System.Reflection;

namespace AttributeReader
{
    public static class AttributeReaderExtensions
    {
        /// <summary>
        /// Retrieves an Attribute property value from an instance or a default value if the attribute is not found.
        /// </summary>
        /// <typeparam name="TSubject">The type to retrieve the attribute from</typeparam>
        /// <typeparam name="TAttribute">The type of the Attribute</typeparam>
        /// <typeparam name="TAttributeValue">The type of the Attribute value to be returned</typeparam>
        /// <param name="subject">An instance of the object you want to retrieve the attribute from.</param>
        /// <param name="attributePropertyAccessor">A member accessor function pointing to the attribute property to read.</param>
        /// <param name="defaultValue">A value to be returned if the attribute is not found.</param>
        /// <returns></returns>
        public static TAttributeValue AttributePropertyValueOrDefault<TSubject, TAttribute, TAttributeValue>(this TSubject subject,
            Func<TAttribute, TAttributeValue> attributePropertyAccessor,
            TAttributeValue defaultValue = default(TAttributeValue))
            where TAttribute : Attribute
        {
            var attribute = typeof(TSubject).GetCustomAttribute<TAttribute>();
            return attribute == null ? defaultValue : attributePropertyAccessor(attribute);
        }
    }
}