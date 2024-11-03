#region

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ploch.Data.Model;

#endregion

namespace Ploch.EditorConfigTools.Models;

public class EditorConfigFile : IHasId<int>, INamed, IHasDescription
{
    public int Id { get; set; }

    [Required]
    public required string Name { get; set; }

    public string? Description { get; set; }

    [Required]
    public string FilePath { get; set; } = null!;

    public bool IsRoot { get; set; }

    [Required]
    public string FileHash { get; set; } = null!;

    public virtual ICollection<ConfigSection>? ConfigSections { get; set; }

    public virtual Project Project { get; set; } = null!;
}
