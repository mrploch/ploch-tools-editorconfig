using Microsoft.EntityFrameworkCore;
using Ploch.EditorConfigTools.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ploch.EditorConfigTools.DataAccess;
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