using System;
using System.Net;

namespace api.DTO
{

    public class PagedResult<TValue> : Result<TValue>
    {
        public int CurrentPage { get; private set; }
        public Uri FirstPage { get; private set; }
        public int TotalRecords { get; private set; }
        public Uri LastPage { get; private set; }
        public object NextPage { get; private set; }
        public object PreviousPage { get; private set; }

        public static PagedResult<TValue> Success(HttpStatusCode statusCode, TValue value, int pageNumber, int pageSize, int totalCount, string meta=null,string message = null) =>
            new()
            {
                StatusCode = statusCode,
                Value = value,
                Message = message,
                Meta = meta,
                CurrentPage = pageNumber,
                TotalRecords = totalCount,
                FirstPage = new Uri($"?currentPage=1&pageSize={pageSize}", UriKind.Relative),
                LastPage = new Uri($"?currentPage={(int)Math.Ceiling((double)totalCount / pageSize)}&pageSize={pageSize}", UriKind.Relative),
                NextPage = pageNumber < totalCount ? new Uri($"?currentPage={pageNumber + 1}&pageSize={pageSize}", UriKind.Relative) : null,
                PreviousPage = pageNumber > 1 ? new Uri($"?currentPage={pageNumber - 1}&pageSize={pageSize}", UriKind.Relative) : null,
            };

        public new static PagedResult<TValue> Failed(HttpStatusCode statusCode, string error, string meta = null,string message=null) =>
            new()
            {
                StatusCode = statusCode,
                Error = error,
                Meta = meta,
                Message = message
            };
    }

}
