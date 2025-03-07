namespace api.DTO.Docusign
{
    public class EnvelopeDataDto
    {
        public string EnvelopeId { get; set; }
        public string RecipientId { get; set; }
        public EnvelopeSummaryDto EnvelopeSummary { get; set; }
    }
}
