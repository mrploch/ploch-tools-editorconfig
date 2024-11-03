#region

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ploch.Data.Model;

#endregion

namespace Ploch.EditorConfigTools.Models;

public class Project : IHasId<int>, INamed, IHasDescription
{
    [Key]
    public int Id { get; set; }

    [Required]
    public required string Name { get; set; }

    public string? Description { get; set; }

    /// <summary>
    ///     Project root path.
    /// </summary>
    [Required]
    public required string Path { get; set; } = null!;

    public virtual ApplicationUser? User { get; set; }

    public virtual ICollection<EditorConfigFile> EditorConfigFiles { get; set; } = null!;
}
