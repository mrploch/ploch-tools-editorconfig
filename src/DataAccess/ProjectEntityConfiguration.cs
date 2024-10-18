using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ploch.EditorConfigTools.Models;

namespace Ploch.EditorConfigTools.DataAccess;

public class ProjectEntityConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.HasKey(e => e.Id);
        builder.HasMany(e => e.EditorConfigFiles).WithOne(e => e.Project).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(e => e.User).WithMany(e => e.Projects).OnDelete(DeleteBehavior.SetNull).IsRequired(false);
    }
}