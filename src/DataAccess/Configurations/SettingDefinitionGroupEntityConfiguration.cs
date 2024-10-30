using Microsoft.EntityFrameworkCore;
using Ploch.EditorConfigTools.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ploch.EditorConfigTools.DataAccess.Configurations;
public class SettingDefinitionGroupEntityConfiguration : IEntityTypeConfiguration<SettingDefinitionGroup>
{
    public void Configure(EntityTypeBuilder<SettingDefinitionGroup> builder)
    {
        builder.HasMany(e => e.SettingDefinitions).WithOne(e => e.SettingDefinitionGroup).OnDelete(DeleteBehavior.Cascade);
        builder.Property(e => e.DefinitionGroupNameRegex).HasDefaultValue(".*\\.");
    }
}