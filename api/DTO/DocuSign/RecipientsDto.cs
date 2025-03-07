using System.Collections.Generic;

namespace api.DTO.Docusign
{
    public class Recipients
    {
        public List<SignerDto> Signers { get; set; }
        public List<CarbonCopyDto> CarbonCopies { get; set; }
    }
}
