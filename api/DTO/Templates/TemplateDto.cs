using System;

namespace api.DTO.Templates;
public class TemplateDto
{
    public Guid TemplateID { get; set; }
    public string DisplayName { get; set; }
    public string FilePath { get; set; }

}