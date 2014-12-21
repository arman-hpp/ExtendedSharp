using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExtendedSharp.Core.Collections;

namespace ExtendedSharp.Core.Extensions
{
    public static class QueryableExtensions
    {
        /// <summary>
        /// Returns a PaginatedList based on the specified IQueryable and page index and page size. The total count is gathered from the query itself.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static PaginatedList<T> ToPaginatedList<T>(this IQueryable<T> query, int pageIndex, int pageSize)
        {
            return new PaginatedList<T>(query, pageIndex, pageSize);
        }

        /// <summary>
        /// Returns a PaginatedList based on the specified IQueryable with the specified page index, page size and total count set. This is for using when the IQueryable already contains a known subset of the full query.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        public static PaginatedList<T> ToPaginatedList<T>(this IQueryable<T> query, int pageIndex, int pageSize, int totalCount)
        {
            return new PaginatedList<T>(query, pageIndex, pageSize, totalCount);
        }
    }
}
