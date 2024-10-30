using Microsoft.EntityFrameworkCore;
using Ploch.EditorConfigTools.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ploch.EditorConfigTools.DataAccess.Configurations;
public class ConfigEntryEntityConfiguration : IEntityTypeConfiguration<ConfigEntry>
{
    public void Configure(EntityTypeBuilder<ConfigEntry> builder)
    {
        builder.HasOne(e => e.ConfigSection).WithMany(e => e.ConfigEntries).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(e => e.SettingDefinition).WithMany(e => e.ConfigEntries).OnDelete(DeleteBehavior.SetNull);
        builder.HasIndex(e => e.Name);
        builder.HasMany(e => e.Comments).WithOne(e => e.ConfigEntry).OnDelete(DeleteBehavior.Cascade);
    }
}