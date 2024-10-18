using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ploch.EditorConfigTools.Models;

namespace Ploch.EditorConfigTools.DataAccess;

public class ConfigEntryEntityConfiguration : IEntityTypeConfiguration<ConfigEntry>
{
    public void Configure(EntityTypeBuilder<ConfigEntry> builder)
    {
        builder.HasOne(e => e.ConfigSection).WithMany(e => e.ConfigEntries).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(e => e.SettingDefinition).WithMany(e => e.ConfigEntries).OnDelete(DeleteBehavior.SetNull);
        builder.HasIndex(e => e.Name);
    }
}