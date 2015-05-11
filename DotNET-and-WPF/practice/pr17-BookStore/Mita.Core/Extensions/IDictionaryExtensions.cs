using System;
using System.Collections.Generic;

namespace Mita.Core
{
    /// <summary>
    /// Extension methods for IDictionary<TKey, TValue> interface.
    /// </summary>
    public static class IDictionaryExtensions
    {
        /// <summary>
        ///     Returns stored value if <paramref name="key"/> exists in dictionary.
        ///     Otherwise add <paramref name="defaultValue"/> to dictionary and return it.
        /// </summary>
        /// <typeparam name="TKey">
        ///     The type of keys in the dictionary.
        /// </typeparam>
        /// <typeparam name="TValue">
        ///     The type of values in the dictionary. By default using default value fot type <typeparamref name="TValue"/>
        /// </typeparam>
        /// <param name="dictionary">
        ///     Dictionary instance from with getting value.
        /// </param>
        /// <param name="key">
        ///     The key of the element to get.
        /// </param>
        /// <param name="defaultValue">
        ///     Value that adds and returns if dictionary doesn't have specified <paramref name="key"/>.
        /// </param>
        /// <returns>
        ///     The element with the specified <paramref name="key"/> or <paramref name="defaultValue"/> 
        ///     if key does not exists in dictionary.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        ///     <paramref name="key"/> is null.
        /// </exception>
        public static TValue GetValueOrAdd<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue @default = default(TValue))
        {
            return dictionary.GetValueOrAdd(key, k => @default);
        }

        public static TValue GetValueOrAdd<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, Func<TValue> getDefault)
        {
            return dictionary.GetValueOrAdd(key, k => getDefault());
        }

        public static TValue GetValueOrAdd<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, Func<TKey, TValue> getDefault)
        {
            if (!dictionary.ContainsKey(key))
            {
                dictionary.Add(key, getDefault(key));
            }

            return dictionary[key];
        }

        /// <summary>
        ///     Returns stored value if <paramref name="key"/> exists in dictionary.
        ///     Otherwise returns <paramref name="defaultValue"/>.
        /// </summary>
        /// <typeparam name="TKey">
        ///     The type of keys in the dictionary.
        /// </typeparam>
        /// <typeparam name="TValue">
        ///     The type of values in the dictionary. By default using default value fot type <typeparamref name="TValue"/>
        /// </typeparam>
        /// <param name="dictionary">
        ///     Dictionary instance from with getting value.
        /// </param>
        /// <param name="key">
        ///     The key of the element to get.
        /// </param>
        /// <param name="defaultValue">
        ///     Value that returns if dictionary doesn't have specified <paramref name="key"/>.
        /// </param>
        /// <returns>
        ///     The element with the specified <paramref name="key"/> or <paramref name="defaultValue"/> 
        ///     if key does not exists in dictionary.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">
        ///     <paramref name="key"/> is null.
        /// </exception>
        public static TValue GetValueSafe<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue @default = default(TValue))
        {
            return dictionary.GetValueOrAdd(key, k => @default);
        }

        public static TValue GetValueSafe<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, Func<TValue> getDefault)
        {
            return dictionary.GetValueOrAdd(key, k => getDefault());
        }

        public static TValue GetValueSafe<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, Func<TKey, TValue> getDefault)
        {
            TValue value;
            if (!dictionary.TryGetValue(key, out value))
            {
                value = getDefault(key);
            }

            return value;
        }

    }
}
