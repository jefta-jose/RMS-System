using System;
using System.Collections.Generic;
using ExcelDataReader;

namespace api.DTO
{


        public class ProjectUploadDto
        {
                public Guid ProjectID { get; set; }
                public string ProjectName { get; set; } = String.Empty;
                public string ProjectId { get; set; }
                public string StatusId { get; set; }
                public string AccountingID { get; set; }
                public DateTime StartDate { get; set; } = DateTime.Now;
                public DateTime EstimatedEndDate { get; set; } = new DateTime(DateTime.Now.AddYears(1).Year, 12, 31, 0, 0, 0, DateTimeKind.Utc);
                public string CustomerName { get; set; } = String.Empty;
                public string LocationName { get; set; } = String.Empty;
                public string SDLName { get; set; } = String.Empty;

        }
}