using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Application.Wrappers
{
    public class PagedResponse<T> : ApiResponse<T>
    {
        public int PageNumber { get; init; }
        public int PageSize { get; init; }
        public int TotalRecords { get; init; }
        public int TotalPages { get; init; }
        //public List<T> Data { get; init; }
        //public bool HasPreviousPage => PageIndex > 1;
        //public bool HasNextPage => PageSize < TotalPages;

        public PagedResponse(T data, int pageNumber, int pageSize, int totalRecords, string message) : base(data, message)
        {
            Data = data;
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalRecords = totalRecords;
            //TotalPages = (int)Math.Ceiling(totalRecords / pageSize);
        }

    }
}
