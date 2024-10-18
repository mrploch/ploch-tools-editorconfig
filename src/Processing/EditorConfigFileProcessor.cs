using IniParser.Parser;
using Ploch.EditorConfigTools.Models;

namespace Ploch.EditorConfigTools.Processing;

public class EditorConfigFileProcessor(SectionProcessor sectionProcessor)
{
    public async Task ExecuteAsync(EditorConfigFile editorConfigFile)
    {
        var parser = new IniDataParser();
        parser.Configuration.CommentString = "#";

        var iniFile = parser.Parse(editorConfigFile.FilePath);

        foreach (var iniFileSection in iniFile.Sections)
        {
            var configSection = new ConfigSection
            {
                FilePattern = iniFileSection.SectionName,
                ConfigEntries = [],
                FileExtensions = [],
                Comments = [],
                Description = iniFileSection.SectionName + " description"
            };
            await sectionProcessor.ExecuteAsync(configSection, iniFileSection);
        }
    }
}