using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class EmployeeType
    {
        public int ID { get; set; }
        public Guid EmployeeTypeID { get; set; }
        public string EmployeeTypeName { get; set; }
        public DateTime? CreatedDTM { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? UpdatedDTM { get; set; }
        public long? UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
        public long? DeletedBy { get; set; }
        public DateTime? DeletedDTM { get; set; }
        [Timestamp]
        public virtual byte[] RowVersion { get; set; }
        public List<Resource> Resources { get; set; }

        public EmployeeType() { }
    }
}
