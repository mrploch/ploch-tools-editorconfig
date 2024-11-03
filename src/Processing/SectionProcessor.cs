using Ploch.IniParser;
using Ploch.Common.Collections;
using Ploch.EditorConfigTools.Models;

namespace Ploch.EditorConfigTools.Processing;
public class SectionProcessor(ConfigEntryProcessor configEntryProcessor, ProcessingContext context)
{
    public async Task ExecuteAsync(ConfigSection editorConfigSection, IniSection iniFileSection, CancellationToken cancellationToken = default)
    {
        iniFileSection.Comments?.ForEach(c => editorConfigSection.Comments!.Add(new Comment { Value = c }));

        editorConfigSection.FilePattern = await CreateFilePatternAsync(iniFileSection.Name, cancellationToken);

        foreach (var keyData in iniFileSection.Entries)
        {
            var entry = new ConfigEntry { Name = keyData.Key, Value = keyData.Value.Value, ConfigSection = editorConfigSection, Comments = [] };
            editorConfigSection.ConfigEntries!.Add(entry);

            await configEntryProcessor.ExecuteAsync(entry, keyData.Value);
        }
    }

    private async Task<FilePattern> CreateFilePatternAsync(string sectionGlob, CancellationToken cancellationToken = default)
    {
        var (fileNamePattern, fileExtensions) = SectionUtils.ParseFileExtensions(sectionGlob);

        var filePattern = await context.GetFilePatternAsync(sectionGlob, cancellationToken);
        if (filePattern != null)
        {
            return filePattern;
        }

        filePattern = new FilePattern { NamePattern = fileNamePattern, GlobPattern = sectionGlob, FileTypes = [] };

        foreach (var fileExtension in fileExtensions)
        {
            var fileType = filePattern.FileTypes.FirstOrDefault(ft => ft.FileExtensions.Any(fe => fe.Id == fileExtension));
            if (fileType != null)
            {
                continue;
            }

            fileType = await context.GetFileTypeAsync(fileExtension);

            if (fileType == null)
            {
                var extension = new FileExtension { Id = fileExtension, Name = $"{fileExtension} File" };
                fileType = new FileType { Name = fileExtension, FileExtensions = [extension] };
            }

            filePattern.FileTypes.Add(fileType);
            context.AddFileType(fileExtension, fileType);
        }

        await context.AddFilePatternAsync(filePattern);

        return filePattern;
    }
}
