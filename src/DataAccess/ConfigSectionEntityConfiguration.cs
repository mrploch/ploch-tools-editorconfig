using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ploch.EditorConfigTools.Models;

namespace Ploch.EditorConfigTools.DataAccess;

public class ConfigSectionEntityConfiguration : IEntityTypeConfiguration<ConfigSection>
{
    public void Configure(EntityTypeBuilder<ConfigSection> builder)
    {
        builder.HasOne(e => e.ConfigSectionType).WithMany(e => e.ConfigSections).IsRequired(false).OnDelete(DeleteBehavior.SetNull);
        builder.HasOne(e => e.EditorConfigFile).WithMany(e => e.ConfigSections).OnDelete(DeleteBehavior.SetNull);
        builder.HasMany(e => e.FileExtensions).WithMany(e => e.ConfigSections);
    }
}