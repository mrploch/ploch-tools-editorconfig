using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ploch.Data.EFCore;
using Ploch.EditorConfigTools.Models;

namespace Ploch.EditorConfigTools.DataAccess;

public class FileTypeEntityConfiguration : IEntityTypeConfiguration<FileType>
{
    public void Configure(EntityTypeBuilder<FileType> builder)
    {
        builder.Property(e => e.FileExtensions).HasConversion<CollectionStringSplitConverter<string>>();
    }
}