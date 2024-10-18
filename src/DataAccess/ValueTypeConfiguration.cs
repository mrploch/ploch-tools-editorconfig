using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ploch.EditorConfigTools.Models;

namespace Ploch.EditorConfigTools.DataAccess;

public class ValueTypeConfiguration : IEntityTypeConfiguration<ValueType>
{
    public void Configure(EntityTypeBuilder<ValueType> builder)
    {
        builder.HasMany(e => e.ValueDefinitions).WithOne(e => e.ValueType).OnDelete(DeleteBehavior.SetNull);
    }
}