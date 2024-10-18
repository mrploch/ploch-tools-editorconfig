using System.Collections.Generic;
using Ploch.Data.Model;

namespace Ploch.EditorConfigTools.Models;

public class ValueType : IHasId<int>, INamed, IHasDescription
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string HandlerType { get; set; } = null!;

    public virtual ICollection<ValueDefinition>? ValueDefinitions { get; set; }
}