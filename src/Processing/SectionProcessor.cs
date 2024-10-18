using IniParser.Model;
using Ploch.EditorConfigTools.Models;

namespace Ploch.EditorConfigTools.Processing;

public class SectionProcessor(ConfigEntryProcessor configEntryProcessor)
{
    public async Task ExecuteAsync(ConfigSection editorConfigSection, SectionData iniFileSection)
    {
        iniFileSection.Comments?.ForEach(c => editorConfigSection.Comments!.Add(new Comment { Value = c }));

        var fileExtensions = SectionUtils.ParseFileExtensions(iniFileSection.SectionName);

        foreach (var fileExtension in fileExtensions.Select(ext => new FileExtension { Id = ext }))
        {
            editorConfigSection.FileExtensions!.Add(fileExtension);
        }

        foreach (var keyData in iniFileSection.Keys)
        {
            var entry = new ConfigEntry { Name = keyData.KeyName, Value = keyData.Value, ConfigSection = editorConfigSection, Comments = [] };

            await configEntryProcessor.ExecuteAsync(entry, keyData);
        }
    }
}