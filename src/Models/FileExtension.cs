#region

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ploch.Data.Model;

#endregion

namespace Ploch.EditorConfigTools.Models;

public class FileExtension : IHasId<string>, IHasDescription
{
    public string? Description { get; set; }

    /// <summary>
    ///     File extension name
    /// </summary>
    [Key]
    public string? Id { get; set; }

    public virtual ICollection<ConfigSectionType>? ConfigSectionTypes { get; set; }

    public virtual ICollection<ConfigSection>? ConfigSections { get; set; }
}