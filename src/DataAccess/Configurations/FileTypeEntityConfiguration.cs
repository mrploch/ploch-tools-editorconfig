using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ploch.EditorConfigTools.Models;

namespace Ploch.EditorConfigTools.DataAccess.Configurations;

public class FileTypeEntityConfiguration : IEntityTypeConfiguration<FileType>
{
    public void Configure(EntityTypeBuilder<FileType> builder)
    {
        builder.HasMany(e => e.FileExtensions).WithOne(e => e.FileType).OnDelete(DeleteBehavior.Cascade);
    }
}
