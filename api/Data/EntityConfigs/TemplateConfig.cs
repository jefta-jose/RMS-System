using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace api.EF.EntityConfigs
{
    public class TempalteConfig : IEntityTypeConfiguration<Template>
    {
        public void Configure(EntityTypeBuilder<Template> builder)
        {
            builder.ToTable("Templates");
            builder.Property(p => p.TemplateID)
                .ValueGeneratedOnAdd();
        }
    }
}