using System;

namespace api.DTO
{
    public class FilterDto
    {
        public string Search { get; set; }
        public Guid LocationID { get; set; }
        public DateTime Week { get; set; }
        public string Status { get; set; }
        public string ReportType { get; set; }

        public Guid SolutionDeliveryLeaderID { get; set; }
        public long? SdlId { get; set; }

        public Guid CustomerID { get; set; }
        public Guid ProjectID { get; set; }
        public long Id { get; set; }

    }
}
