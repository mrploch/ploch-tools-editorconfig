#region

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ploch.Data.Model;

#endregion

namespace Ploch.EditorConfigTools.Models;

public class ValueDefinition : IHasId<int>, IHasValue<string>, IHasDescription
{
    // public virtual ICollection<SettingDefinition>? ModifiersSettingDefinitions { get; set; }
    public int Id { get; set; }

    public string? Description { get; set; }

    [Required]
    public string Value { get; set; } = null!;

    public virtual ICollection<SettingDefinition>? ValueSettingDefinitions { get; set; }

    public virtual ValueType ValueType { get; set; } = null!;
}