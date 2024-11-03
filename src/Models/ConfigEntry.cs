#region

using System.Collections.Generic;
using Ploch.Data.Model;

#endregion

namespace Ploch.EditorConfigTools.Models;

public record ConfigEntry : IHasId<int>, INamed, IHasValue<string>
{
    public int Id { get; set; }

    public string? Value { get; set; }

    public string? Name { get; set; }

    public virtual ConfigSection? ConfigSection { get; set; }

    public virtual SettingDefinition? SettingDefinition { get; set; }

    public string? Modifier { get; set; }

    public string? OriginalValue { get; set; }

    public virtual ICollection<Comment>? Comments { get; set; }
}
