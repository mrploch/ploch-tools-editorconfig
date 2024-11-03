#region

using System.Collections.Generic;
using Ploch.Data.Model;

#endregion

namespace Ploch.EditorConfigTools.Models;

public class SettingCategory : IHasId<int>, INamed, IHierarchicalWithParentComposite<SettingCategory>,
                               IHierarchicalWithChildrenComposite<SettingCategory>
{
    public int Id { get; set; }

    public virtual ICollection<SettingCategory>? Children { get; set; }

    public virtual SettingCategory? Parent { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<SettingDefinition>? SettingDefinitions { get; set; }
}
