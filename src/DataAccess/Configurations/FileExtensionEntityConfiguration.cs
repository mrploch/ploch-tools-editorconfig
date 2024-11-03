using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ploch.EditorConfigTools.Models;

namespace Ploch.EditorConfigTools.DataAccess.Configurations;

public class FileExtensionEntityConfiguration : IEntityTypeConfiguration<FileExtension>
{
    public void Configure(EntityTypeBuilder<FileExtension> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).HasMaxLength(50);
        builder.Property(e => e.Name).HasMaxLength(100).IsRequired();
        builder.Property(e => e.Description);
    }
}
