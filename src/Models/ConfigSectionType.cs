#region

using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Ploch.Data.Model;

#endregion

namespace Ploch.EditorConfigTools.Models;

[Index(nameof(NormalizedExtensions))]
public class ConfigSectionType : IHasId<int>, INamed, IHasDescription
{
    public string? Description { get; set; }

    public int Id { get; set; }

    public string? Name { get; set; }

    public string? FilePattern { get; set; }

    public string? NormalizedExtensions { get; set; }

    public virtual ICollection<FileExtension>? FileExtensions { get; set; }

    public virtual ICollection<ConfigSection>? ConfigSections { get; set; }
}