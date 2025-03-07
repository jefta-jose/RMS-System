using System;

namespace api.DTO.Docusign
{
    public class SignerDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string RecipientId { get; set; }
        public string Status { get; set; }
        public string CompletedCount { get; set; }
        public DateTime SignedDateTime { get; set; }
        public DateTime DeliveredDateTime { get; set; }
        public DateTime SentDateTime { get; set; }
        public string RecipientType { get; set; }
    }
}
