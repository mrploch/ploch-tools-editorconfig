#region

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ploch.Data.Model;

#endregion

namespace Ploch.EditorConfigTools.Models;

public class FilePattern : IHasId<int>, IHasDescription
{
    /// <summary>
    ///     File extension name
    /// </summary>
    [Key]
    public int Id { get; set; }

    public string? Description { get; set; }

    public string NamePattern { get; set; } = null!;

    public string GlobPattern { get; set; } = null!;

    public virtual ICollection<FileType> FileTypes { get; set; } = null!;

    public virtual ICollection<ConfigSectionType>? ConfigSectionTypes { get; set; }

    public virtual ICollection<ConfigSection>? ConfigSections { get; set; }
}