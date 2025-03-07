using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class BusinessUnit
    {
        public long ID { get; set; }
        public Guid BusinessUnitID { get; set; }
        public string BusinessUnitName { get; set; }
        public long CreatedBy { get; set; }
        public DateTime? CreatedDTM { get; set; }
        public long UpdatedBy { get; set; }
        public DateTime? UpdatedDTM { get; set; }
        public bool IsDeleted { get; set; }
        [Timestamp]
        public virtual byte[] RowVersion { get; set; }
    }
}