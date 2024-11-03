#region

using System.Collections.Generic;
using Ploch.Data.Model;

#endregion

namespace Ploch.EditorConfigTools.Models;

public class ConfigSection : IHasId<int>, IHasDescription, IHierarchicalParentChildrenComposite<ConfigSection>
{
    public int Id { get; set; }

    public string? Description { get; set; }

    public virtual ConfigSection? Parent { get; set; }

    public virtual ICollection<ConfigSection>? Children { get; set; }

    public string? GlobPattern { get; set; }

    public virtual ConfigSectionType? ConfigSectionType { get; set; }

    public virtual FilePattern FilePattern { get; set; } = null!;

    public virtual EditorConfigFile? EditorConfigFile { get; set; }

    public virtual ICollection<ConfigEntry>? ConfigEntries { get; set; }

    public virtual ICollection<Comment>? Comments { get; set; }
}
