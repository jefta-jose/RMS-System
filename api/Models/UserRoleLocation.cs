using System.ComponentModel.DataAnnotations;
using System;

namespace api.Models
{
    public class UserRoleLocation
    {
        public long ID { get; set; }
        public Guid UserRoleLocationID { get; set; }
        public long UserRoleID { get; set; }
        public long LocationID { get; set; }
        public DateTime CreatedDTM { get; set; }
        public long CreatedBy { get; set; }
        public DateTime? UpdatedDTM { get; set; }
        public long? UpdatedBy { get; set; }
        public Boolean IsDeleted { get; set; }
        public DateTime? DeletedDTM { get; set; }
        public long? DeletedBy { get; set; }
        [Timestamp]
        public virtual byte[] RowVersion { get; set; }
        public Location Location { get; set; }
        public UserRole UserRole { get; set; }
        public UserRoleLocation() { }
    }
}
