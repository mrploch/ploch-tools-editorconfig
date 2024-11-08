﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ploch.EditorConfigTools.Models;

namespace Ploch.EditorConfigTools.DataAccess.Configurations;

public class SettingDefinitionEntityConfiguration : IEntityTypeConfiguration<SettingDefinition>
{
    public void Configure(EntityTypeBuilder<SettingDefinition> builder)
    {
        builder.HasMany(e => e.Categories).WithMany(e => e.SettingDefinitions);
        builder.HasMany(e => e.AllowedValues).WithMany(e => e.ValueSettingDefinitions);
        builder.HasMany(e => e.ConfigEntries).WithOne(e => e.SettingDefinition).OnDelete(DeleteBehavior.NoAction);
    }
}
