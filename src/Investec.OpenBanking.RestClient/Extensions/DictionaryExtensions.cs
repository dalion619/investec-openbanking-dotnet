using System.Collections.Generic;
using System.ComponentModel;

namespace Investec.OpenBanking.RestClient.Extensions
{
    public static class DictionaryExtensions
    {
        public static IDictionary<string, object> ToDictionary(this object source) => source.ToDictionary<object>();

        public static IDictionary<string, T> ToDictionary<T>(this object source)
        {
            var dictionary = new Dictionary<string, T>();
            foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(source))
            {
                AddPropertyToDictionary(property, source, dictionary);
            }

            return dictionary;
        }

        private static void AddPropertyToDictionary<T>(PropertyDescriptor property, object source,
                                                       Dictionary<string, T> dictionary)
        {
            var obj = property.GetValue(source);
            if (!IsOfType<T>(obj))
            {
                return;
            }

            dictionary.Add(property.Name, (T) obj);
        }

        private static bool IsOfType<T>(object value) => value is T;

        public static T ToObject<T>(this IDictionary<string, object> source)
            where T : class, new()
        {
            var someObject = new T();
            var someObjectType = someObject.GetType();

            foreach (var item in source)
            {
                someObjectType
                    .GetProperty(item.Key)
                    .SetValue(someObject, item.Value, null);
            }

            return someObject;
        }
    }
}