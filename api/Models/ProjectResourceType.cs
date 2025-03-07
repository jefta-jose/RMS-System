using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class ProjectResourceType
    {
        public long ID { get; set; }
        public Guid projectResourceTypeId { get; set; }
        public int Amount { get; set; }
        public DateTime CreatedDTM { get; set; }
        public long CreatedBy { get; set; }
        public DateTime UpdatedDTM { get; set; }
        public long UpdatedBy { get; set; }
        [Timestamp]
        public virtual byte[] RowVersion { get; set; }
        public Project Project { get; set; }
        public long ProjectId { get; set; }
        public ResourceType ResourceType { get; set; }
        public int ResourceTypeId { get; set; }
        public string StartBy { get; set; }
        public ProjectResourceType() { }
    }
}