﻿using Microsoft.EntityFrameworkCore;
using Ploch.EditorConfigTools.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ploch.EditorConfigTools.DataAccess.Configurations;
public class ConfigSectionTypeEntityConfiguration : IEntityTypeConfiguration<ConfigSectionType>
{
    public void Configure(EntityTypeBuilder<ConfigSectionType> builder)
    {
        builder.HasOne(e => e.FilePattern).WithMany(e => e.ConfigSectionTypes).OnDelete(DeleteBehavior.NoAction);
        builder.HasMany(e => e.ConfigSections).WithOne(e => e.ConfigSectionType).IsRequired(false).OnDelete(DeleteBehavior.Cascade);
    }
}