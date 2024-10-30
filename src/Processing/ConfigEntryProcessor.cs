using Ploch.Common.Collections;
using Ploch.EditorConfigTools.Models;
using KeyData = Ploch.IniParser.KeyData;

namespace Ploch.EditorConfigTools.Processing;

public class ConfigEntryProcessor(SettingDefinitionFactory settingDefinitionFactory, ProcessingContext processingContext)
{
    public async Task ExecuteAsync(ConfigEntry configEntry, KeyData keyData)
    {
        configEntry.OriginalValue = keyData.Value;
        configEntry.Value = keyData.Value;
        configEntry.Modifier = keyData.Key;

        var settingDefinition = await processingContext.GetSettingDefinitionAsync(keyData.Key);

        if (settingDefinition == null)
        {
            settingDefinition = settingDefinitionFactory.Create(keyData.Key);

            await processingContext.AddSettingDefinitionAsync(settingDefinition);
        }

        configEntry.SettingDefinition = settingDefinition;

        keyData.Comments.ForEach(c => configEntry.Comments!.Add(new Comment { Value = c }));
    }
}