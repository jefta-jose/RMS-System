using System;

namespace api.DTO.Docusign
{
    public class EnvelopeSummaryDto
    {
        public string Status { get; set; }
        public string EnvelopeId { get; set; }
        public DateTime ExpireDateTime { get; set; }
        public string ExpireAfter { get; set; }
        public Recipients Recipients { get; set; }
    }
}
