using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ploch.EditorConfigTools.Models;

namespace Ploch.EditorConfigTools.DataAccess.Configurations;

public class SettingCategoryEntityConfiguration : IEntityTypeConfiguration<SettingCategory>
{
    public void Configure(EntityTypeBuilder<SettingCategory> builder)
    {
        builder.HasMany(e => e.Children).WithOne(e => e.Parent).IsRequired(false);
    }
}
