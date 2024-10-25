using System.IO.Abstractions;
using IniParser;
using IniParser.Model;
using Microsoft.Extensions.Logging;
using Ploch.Common.Cryptography;
using ConfigSection = Ploch.EditorConfigTools.Models.ConfigSection;
using EditorConfigFile = Ploch.EditorConfigTools.Models.EditorConfigFile;

namespace Ploch.EditorConfigTools.Processing;

public class EditorConfigFileProcessor(SectionProcessor sectionProcessor, IFileSystem fileSystem, ILogger<EditorConfigFileProcessor> logger)
{
    /// <summary>
    ///     Asynchronously processes an EditorConfig file, parsing its contents
    ///     and updating the provided EditorConfigFile instance with the parsed data.
    /// </summary>
    /// <param name="editorConfigFile">The EditorConfigFile instance to be processed and updated.</param>
    /// <returns>A Task representing the asynchronous operation.</returns>
    public async Task ExecuteAsync(EditorConfigFile editorConfigFile)
    {
        // var parser = new IniDataParser();
        // parser.Configuration.CommentString = "#";
        var fileStream = fileSystem.FileStream.New(editorConfigFile.FilePath, FileMode.Open);
        var fileHash = fileStream.ToMD5HashString();
        if (editorConfigFile.FilePath == fileHash)
        {
            logger.LogInformation("File {FilePath} has not changed. Skipping processing.", editorConfigFile.FilePath);

            return;
        }

        editorConfigFile.FileHash = fileHash;

        editorConfigFile.ConfigSections!.Clear();
        var fileDataParser = new FileIniDataParser();

        fileDataParser.Parser.Configuration.AllowDuplicateKeys = true;
        fileDataParser.Parser.Configuration.AllowDuplicateSections = true;
        fileDataParser.Parser.Configuration.CommentString = "#";

        fileStream.Seek(0, SeekOrigin.Begin);
        IniData? iniFile;
        using var streamReader = new StreamReader(fileStream);
        try
        {
            iniFile = fileDataParser.ReadData(streamReader);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }

        foreach (var iniFileSection in iniFile.Sections)
        {
            var configSection = new ConfigSection
            {
                GlobPattern = iniFileSection.SectionName,
                ConfigEntries = [],
                Comments = [],
                Description = iniFileSection.SectionName + " description"
            };
            editorConfigFile.ConfigSections!.Add(configSection);

            await sectionProcessor.ExecuteAsync(configSection, iniFileSection);
        }
    }
}