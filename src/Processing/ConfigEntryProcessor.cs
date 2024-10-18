using IniParser.Model;
using Ploch.Data.GenericRepository;
using Ploch.EditorConfigTools.Models;

namespace Ploch.EditorConfigTools.Processing;

public class ConfigEntryProcessor(
    IReadWriteRepositoryAsync<SettingDefinition, Guid> settingDefinitionRepository,
    SettingDefinitionFactory settingDefinitionFactory,
    ProcessingContext processingContext)
{
    public async Task ExecuteAsync(ConfigEntry configEntry, KeyData keyData)
    {
        configEntry.OriginalValue = keyData.Value;
        configEntry.Value = keyData.Value;
        configEntry.Modifier = keyData.KeyName;

        var settingDefinition = await processingContext.GetSettingDefinitionAsync(keyData.KeyName);

        if (settingDefinition == null)
        {
            settingDefinition = settingDefinitionFactory.Create(keyData.KeyName);

            processingContext.AddSettingDefinition(settingDefinition);
            await settingDefinitionRepository.AddAsync(settingDefinition);
        }

        configEntry.SettingDefinition = settingDefinition;

        keyData.Comments.ForEach(c => configEntry.Comments!.Add(new Comment { Value = c }));
    }
}