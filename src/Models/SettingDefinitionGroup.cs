using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ploch.Data.Model;

namespace Ploch.EditorConfigTools.Models;

public class SettingDefinitionGroup : IHasId<int>, INamed, IHasDescription
{
    public int Id { get; set; }

    [Required]
    public required string Name { get; set; }

    public string? Description { get; set; }

    [Required]
    public string DefinitionGroupNameRegex { get; set; } = ".*\\.";

    public virtual List<SettingDefinition>? SettingDefinitions { get; set; }
}
