using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ploch.EditorConfigTools.Models;

namespace Ploch.EditorConfigTools.DataAccess.Configurations;

public class ConfigSectionEntityConfiguration : IEntityTypeConfiguration<ConfigSection>
{
    public void Configure(EntityTypeBuilder<ConfigSection> builder)
    {
        builder.HasOne(e => e.ConfigSectionType).WithMany(e => e.ConfigSections).IsRequired(false).OnDelete(DeleteBehavior.SetNull);
        builder.HasOne(e => e.EditorConfigFile).WithMany(e => e.ConfigSections).OnDelete(DeleteBehavior.SetNull);
        builder.HasOne(e => e.FilePattern).WithMany(e => e.ConfigSections);
        builder.HasMany(e => e.ConfigEntries).WithOne(e => e.ConfigSection).IsRequired(false).OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(e => e.Comments).WithOne(e => e.ConfigSection).IsRequired(false).OnDelete(DeleteBehavior.Cascade);
    }
}
