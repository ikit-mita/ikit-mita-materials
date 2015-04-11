using System;
using System.Linq;
using System.Reflection;

namespace Mita.Core
{
    public static class GenericExtensions
    {
        /// <summary>
        /// Copy properties values from <paramref name="sourceObj"/>. Matches by property name.
        /// </summary>
        /// <typeparam name="TTo"></typeparam>
        /// <typeparam name="TFrom"></typeparam>
        /// <param name="targetObj"></param>
        /// <param name="sourceObj"></param>
        /// <returns></returns>
        public static TTo CopyProperties<TTo, TFrom>(this TTo targetObj, TFrom sourceObj)
            where TTo : class
            where TFrom : class
        {
            Check.NotNull(targetObj, "targetObj");

            if (sourceObj == null)
            {
                return targetObj;
            }

            bool sameClass = targetObj.GetType() == sourceObj.GetType();

            var propertyLinks = targetObj.GetType()
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Where(prop => prop.CanRead && prop.CanWrite)
                .Select(prop => new
                    {
                        ToProperty = prop,
                        FromProp = sameClass ? prop : GetSourceProperty(sourceObj.GetType(), prop.Name)
                    })
                .Where(desc => desc.FromProp != null)
                .ToArray();

            foreach (var link in propertyLinks)
            {
                try
                {
                    object value = link.FromProp.GetValue(sourceObj);
                    link.ToProperty.SetValue(targetObj, value);
                }
                catch (Exception)
                {
                    System.Diagnostics.Debug.WriteLine(
                        "Property {0} has different types in {1} and {2}".FormatWith(link.FromProp.Name, link.FromProp.ReflectedType.Name, link.ToProperty.ReflectedType.Name));
                }
            }

            return targetObj;
        }

        private static PropertyInfo GetSourceProperty(Type type, string propertyName)
        {
            PropertyInfo property = type.GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance);
            return property != null && property.CanRead ? property : null;
        }

        /// <summary>
        /// Returns empty string for <value>null</value>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToStringSafe<T>(this T obj) where T : class
        {
            return obj == null
                ? string.Empty
                : obj.ToString();
        }

        /// <summary>
        /// Returns empty string for <value>null</value>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToStringSafe<T>(this T? obj) where T : struct
        {
            return obj == null
                ? string.Empty
                : obj.ToString();
        }
    }
}
