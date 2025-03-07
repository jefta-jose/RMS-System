using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTO.Resource
{
    public class GetAvailabilityReportDto
    {
        public long Id { get; set; }
        public string ResourceName {  get; set; }
        public string Role {  get; set; }
        public long? BillType { get; set; }
        public string Location { get; set; }
        public string SDL {  get; set; }
        public decimal Available { get {

                if(TotalBillableHours > 40)
                {
                    return 0;
                }
                else
                {
                    return 100 - (100 * TotalBillableHours / 40);
                }
            }
            }
        public DateTime? AvailableOn { get; set; }
        public decimal TotalBillableHours { get; internal set; }
        public long? ProjectId { get; set; }
    }
}