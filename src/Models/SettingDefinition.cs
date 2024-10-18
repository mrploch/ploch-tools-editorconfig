#region

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ploch.Data.Model;

#endregion

namespace Ploch.EditorConfigTools.Models;

public class SettingDefinition : IHasId<Guid>
{
    // public virtual ICollection<ValueDefinition>? AllowedModifiers { get; set; }

    /// <summary>
    ///     Setting Name
    /// </summary>
    [Key]
    public Guid Id { get; set; }

    public required string Name { get; set; } = null!;

    public string? SettingNameRegex { get; set; }

    public virtual ICollection<ConfigEntry>? ConfigEntries { get; set; }

    public virtual ICollection<SettingCategory>? Categories { get; set; }

    public virtual ICollection<ValueDefinition>? AllowedValues { get; set; }
}