using Ploch.Data.GenericRepository;
using Ploch.EditorConfigTools.Models;

namespace Ploch.EditorConfigTools.Processing;

public class ProcessingContext(IReadRepositoryAsync<SettingDefinition, Guid> settingDefinitionRepository)
{
    private readonly Dictionary<string, SettingDefinition> _settingDefinitions = new();

    public async Task<SettingDefinition?> GetSettingDefinitionAsync(string sectionName)
    {
        var section = _settingDefinitions.ContainsKey(sectionName)
            ? _settingDefinitions[sectionName]!
            : await settingDefinitionRepository.GetAsync(q => q.Name == sectionName);
        return section;
    }

    public void AddSettingDefinition(SettingDefinition settingDefinition)
    {
        _settingDefinitions.Add(settingDefinition.Name, settingDefinition);
    }
}