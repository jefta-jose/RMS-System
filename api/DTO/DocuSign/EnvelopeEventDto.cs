using System;

namespace api.DTO.Docusign
{
    public class EnvelopeEventDto
    {
        public string Event { get; set; }
        public DateTime GeneratedDateTime { get; set; }
        public EnvelopeDataDto Data { get; set; }
    }
}
