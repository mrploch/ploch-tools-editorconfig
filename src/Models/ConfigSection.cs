#region

using System.Collections.Generic;
using Ploch.Data.Model;

#endregion

namespace Ploch.EditorConfigTools.Models;

public class ConfigSection : IHasId<int>, IHasDescription
{
    public string? Description { get; set; }

    public int Id { get; set; }

    public string? FilePattern { get; set; }

    public virtual ConfigSectionType? ConfigSectionType { get; set; }

    public virtual ICollection<FileExtension>? FileExtensions { get; set; }

    public virtual EditorConfigFile? EditorConfigFile { get; set; }

    public virtual ICollection<ConfigEntry>? ConfigEntries { get; set; }

    public virtual ICollection<Comment>? Comments { get; set; }
}