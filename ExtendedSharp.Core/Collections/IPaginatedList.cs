using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtendedSharp.Core.Collections
{
    public interface IPaginatedList : IList, ICollection, IEnumerable
    {
        int PageIndex { get; }

        int PageSize { get; }

        int TotalCount { get; }

        int TotalPages { get; }

        bool HasPreviousPage { get; }

        bool HasNextPage { get; }
    }

    public interface IPaginatedList<T> : IPaginatedList, IList<T>, ICollection<T>, IEnumerable<T>
    {

    }
}
