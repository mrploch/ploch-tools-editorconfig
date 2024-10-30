using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ploch.EditorConfigTools.Models;

namespace Ploch.EditorConfigTools.DataAccess.Configurations;

public class FilePatternEntityConfiguration : IEntityTypeConfiguration<FilePattern>
{
    public void Configure(EntityTypeBuilder<FilePattern> builder)
    {
        builder.HasMany(e => e.FileTypes).WithMany(e => e.FilePatterns);
        builder.HasMany(e => e.ConfigSectionTypes).WithOne(e => e.FilePattern).OnDelete(DeleteBehavior.SetNull);
        builder.HasMany(e => e.ConfigSections).WithOne(e => e.FilePattern).OnDelete(DeleteBehavior.SetNull);
    }
}