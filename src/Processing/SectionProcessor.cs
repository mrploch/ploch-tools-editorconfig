using IniParser.Model;
using Ploch.EditorConfigTools.Models;

namespace Ploch.EditorConfigTools.Processing;
public class SectionProcessor(ConfigEntryProcessor configEntryProcessor, ProcessingContext context)
{
    public async Task ExecuteAsync(ConfigSection editorConfigSection, SectionData iniFileSection)
    {
        iniFileSection.Comments?.ForEach(c => editorConfigSection.Comments!.Add(new Comment { Value = c }));

        editorConfigSection.FilePattern = await CreateFilePatternAsync(iniFileSection.SectionName);

        foreach (var keyData in iniFileSection.Keys)
        {
            var entry = new ConfigEntry { Name = keyData.KeyName, Value = keyData.Value, ConfigSection = editorConfigSection, Comments = [] };
            editorConfigSection.ConfigEntries!.Add(entry);

            await configEntryProcessor.ExecuteAsync(entry, keyData);
        }
    }

    private async Task<FilePattern> CreateFilePatternAsync(string sectionGlob)
    {
        var (fileNamePattern, fileExtensions) = SectionUtils.ParseFileExtensions(sectionGlob);

        var filePattern = await context.GetFilePatternAsync(sectionGlob) ??
                          new FilePattern { NamePattern = fileNamePattern, GlobPattern = sectionGlob, FileTypes = [ ] };

        foreach (var fileExtension in fileExtensions)
        {
            var fileType = filePattern.FileTypes.FirstOrDefault(ft => ft.FileExtensions.Contains(fileExtension));
            if (fileType != null)
            {
                continue;
            }

            fileType = await context.GetFileTypeAsync(fileExtension) ??
                       new FileType { Name = fileExtension, FileExtensions = [ fileExtension ] };

            filePattern.FileTypes.Add(fileType);
        }

        await context.AddFilePatternAsync(filePattern);

        return filePattern;
    }
}