using Ploch.EditorConfigTools.Models;

namespace Ploch.EditorConfigTools.Processing;

public class SettingDefinitionFactory
{
    public SettingDefinition Create(string name)
    {
        return new SettingDefinition { Name = name };
    }
}
