using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtendedSharp.Core.Extensions
{
    public static class NameValueCollectionExtensions
    {
        public static IDictionary<string, object> ToDictionary(this NameValueCollection collection)
        {
            var dict = new Dictionary<string, object>();

            if (collection != null)
            {
                foreach (var key in collection.AllKeys)
                {
                    dict.Add(key, collection[key]);
                }
            }

            return dict;
        }
    }
}
