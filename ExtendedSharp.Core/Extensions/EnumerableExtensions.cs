using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ExtendedSharp.Core.Collections;

namespace ExtendedSharp.Core.Extensions
{
    public static class EnumerableExtensions
    {
        public static string ToDelimString(this IEnumerable<string> arr, string delim = ",")
        {
            var ans = "";
            var Enum = arr.GetEnumerator();
            Enum.MoveNext();
            while (Enum.Current != null)
            {
                ans += Enum.Current;
                if (Enum.MoveNext())
                    ans += delim;
                else
                    break;
            }
            return ans;
        }

        /// <summary>
        /// Returns a PaginatedList<> based on the specified IEnumerable<> and page index and page size. The total count is gathered from the IEnumerable itself.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static PaginatedList<T> ToPaginatedList<T>(this IEnumerable<T> collection, int pageIndex, int pageSize)
        {
            return new PaginatedList<T>(collection.AsQueryable(), pageIndex, pageSize);
        }

        /// <summary>
        /// Returns a PaginatedList<> based on the specified IEnumerable with the specified page index, page size and total count set. This is for using when the IEnumerable contains a known subset of the full data set.
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public static PaginatedList<T> ToPaginatedList<T>(this IEnumerable<T> collection, int pageIndex, int pageSize, int totalCount)
        {
            return new PaginatedList<T>(collection.AsQueryable(), pageIndex, pageSize, totalCount);
        }

        // <summary>
        // Returns a boolean indicating whether the IEnumerable contains any matches to the predicate
        // </summary>
        // <typeparam name="T"></typeparam>
        // <param name="collection">The IEnumerable to search</param>
        // <param name="predicate">The predicate to search for</param>
        // <returns></returns>
        public static bool Contains<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
        {
            return collection.Where(predicate).Any();
        }

        /// <summary>
        /// Returns a boolean indicating if the IEnumerable is Empty.
        /// </summary>
        /// <param name="collection">The IEnumerable object to check</param>
        /// <returns></returns>
        public static bool IsEmpty(this System.Collections.IEnumerable collection)
        {
            foreach (var v in collection)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Returns a boolean indicating whether the IEnumerable is Empty.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection">The IEnumerable<> object to check</param>
        /// <returns></returns>
        public static bool IsEmpty<T>(this IEnumerable<T> collection)
        {
            return !collection.Any();
        }

        /// <summary>
        /// Returns a boolean indicating whether the IEnumerable is Null or Empty.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection">The IEnumerable<> object to check</param>
        /// <returns></returns>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> collection)
        {
            return collection.IsNull() || collection.IsEmpty();
        }

        /// <summary>
        /// Performs the specified action on each element in the IEnumerable<>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="action"></param>
        public static void Each<T>(this IEnumerable<T> collection, Action<T> action)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("collection");
            }
            if (action == null)
            {
                throw new ArgumentNullException("action");
            }
            foreach (var item in collection)
            {
                action(item);
            }
        }

        /// <summary>
        /// Performs the specified action on each element in the IEnumerable
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="action"></param>
        public static void Each(this IEnumerable collection, Action<object> action)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("collection");
            }
            if (action == null)
            {
                throw new ArgumentNullException("action");
            }
            foreach (var item in collection)
            {
                action(item);
            }
        }
    }
}