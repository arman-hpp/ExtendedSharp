using System.Collections.Generic;
using System.Collections.Specialized;
using System.Dynamic;

namespace ExtendedSharp.Core.Extensions
{
    public static class DictionaryExtensions
    {
        /// <summary>
        /// Converts the IDictionary instance into a ExpandoObject.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        public static ExpandoObject ToExpando(this IDictionary<string, object> dictionary)
        {
            var expando = new ExpandoObject();
            var expandoDict = (IDictionary<string, object>)expando;

            foreach (var item in dictionary)
            {
                var value = item.Value as IDictionary<string, object>;
                if (value != null)
                {
                    var d = value;
                    expandoDict.Add(item.Key, d.ToExpando());
                }
                else
                {
                    expandoDict.Add(item);
                }
            }

            return expando;
        }

        /// <summary>
        /// Converts ths IDictionary instance into a NameValueCollection.
        /// </summary>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        public static NameValueCollection ToNameValueCollection(this IDictionary<string, string> dictionary)
        {
            if (dictionary == null)
            {
                return null;
            }

            var col = new NameValueCollection();
            foreach (var item in dictionary)
            {
                col.Add(item.Key, item.Value);
            }
            return col;
        }

        /// <summary>
        /// Returns a new instance of System.Collections.Generic.SortedDictionary(TKey,TValue) that is based on the specified Dictionary(TKey,TValue) and uses the default System.Collections.Generic.IComparer(T) implementation for the key type
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dict"></param>
        /// <returns></returns>
        public static SortedDictionary<TKey, TValue> Sort<TKey, TValue>(this Dictionary<TKey, TValue> dict)
        {
            return new SortedDictionary<TKey, TValue>(dict);
        }

        /// <summary>
        /// Returns a new instance of System.Collections.Generic.SortedDictionary(TKey,TValue) that is based on the specified Dictionary(TKey,TValue) and uses the specified System.Collections.Generic.IComparer(T) to compare keys
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dict"></param>
        /// <param name="comparer"></param>
        /// <returns></returns>
        public static SortedDictionary<TKey, TValue> Sort<TKey, TValue>(this Dictionary<TKey, TValue> dict, IComparer<TKey> comparer)
        {
            return new SortedDictionary<TKey, TValue>(dict, comparer);
        }
    }


}
