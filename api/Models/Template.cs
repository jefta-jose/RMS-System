using System;

namespace api.Models
{
    public class Template
    {
        public long ID { get; set; }
        public Guid TemplateID { get; set; }
        public string DisplayName { get; set; }
        public string FilePath { get; set; }
        public DateTime CreatedDTM { get; set; }
        public long? CreatedBy { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDTM { get; set; }
        public long? DeletedBy { get; set; }
    }
}