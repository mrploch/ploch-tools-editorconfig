using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ploch.EditorConfigTools.Models;

namespace Ploch.EditorConfigTools.DataAccess.Configurations;

public class EditorConfigFileEntityConfiguration : IEntityTypeConfiguration<EditorConfigFile>
{
    public void Configure(EntityTypeBuilder<EditorConfigFile> builder)
    {
        builder.HasMany(e => e.ConfigSections).WithOne(e => e.EditorConfigFile).OnDelete(DeleteBehavior.Cascade);
    }
}
