using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class Location
    {
        public long ID { get; set; }
        public Guid LocationID { get; set; }
        public string Name { get; set; }
        public long CreatedBy { get; set; }
        public long? UserID { get; set; }
        public DateTime? CreatedDTM { get; set; }
        public long UpdatedBy { get; set; }
        public DateTime? UpdatedDTM { get; set; }
        public bool IsDeleted { get; set; }
        [Timestamp]
        public virtual byte[] RowVersion { get; set; }
        public User User { get; set; }
        public List<UserLocation> UserLocations { get; set; }

        public Location() { }
    }
}