using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtendedSharp.Core.Collections
{
    public interface IDataPage
    {
        IPaginatedList Data { get; }

        int PageIndex { get; }

        int TotalCount { get; }

        int TotalPages { get; }
    }

    public interface IDataPage<T> : IDataPage
    {
        IPaginatedList<T> Data { get; }

        int PageIndex { get; }

        int TotalCount { get; }

        int TotalPages { get; }
    }
}
