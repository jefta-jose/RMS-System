using api.DTO;
using System;

namespace api.Helpers.Filter
{
    public class PaginationFilter : FilterDto
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public bool Trace { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? ProjectHealth { get; set; }
        public PaginationFilter()
        {
            PageNumber = 1;
            PageSize = 5;
        }
        public PaginationFilter(int pageNumber, int pageSize, string search = null, bool trace = false, DateTime? startDate = null, DateTime? endDate = null, string reportType = "pdf")
        {
            PageNumber = pageNumber < 1 ? 1 : pageNumber;
            PageSize = pageSize > 10 ? 10 : pageSize;
            Search = search;
            Trace = trace;
            StartDate = startDate;
            EndDate = endDate;
            ReportType = reportType;
        }
    }
}