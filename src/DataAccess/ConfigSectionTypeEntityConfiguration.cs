using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ploch.EditorConfigTools.Models;

namespace Ploch.EditorConfigTools.DataAccess;

public class ConfigSectionTypeEntityConfiguration : IEntityTypeConfiguration<ConfigSectionType>
{
    public void Configure(EntityTypeBuilder<ConfigSectionType> builder)
    {
        builder.HasMany(e => e.FileExtensions).WithMany(e => e.ConfigSectionTypes);
    }
}