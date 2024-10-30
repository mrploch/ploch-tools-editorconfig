using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ploch.EditorConfigTools.Models;

namespace Ploch.EditorConfigTools.DataAccess.Configurations;

public class ValueDefinitionConfiguration : IEntityTypeConfiguration<ValueDefinition>
{
    public void Configure(EntityTypeBuilder<ValueDefinition> builder)
    {
        builder.HasMany(e => e.ValueSettingDefinitions).WithMany(e => e.AllowedValues);
        //   builder.HasMany(e => e.ModifiersSettingDefinitions).WithMany(e => e.AllowedValues);
    }
}