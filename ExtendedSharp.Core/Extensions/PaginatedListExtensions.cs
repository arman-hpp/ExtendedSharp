using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExtendedSharp.Core.Collections;

namespace ExtendedSharp.Core.Extensions
{
    public static class IPaginatedListExtensions
    {
        public static DataPage ToDataPage(this IPaginatedList paginatedList)
        {
            return new DataPage(paginatedList);
        }

        public static DataPage<T> ToDataPage<T>(this IPaginatedList<T> paginatedList)
        {
            return new DataPage<T>(paginatedList);
        }
    }
}
