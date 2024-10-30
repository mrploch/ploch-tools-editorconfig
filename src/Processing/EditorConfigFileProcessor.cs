using System.IO.Abstractions;
using System.Security;
using Microsoft.Extensions.Logging;
using Ploch.Common.Cryptography;
using Ploch.IniParser;
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
    /// <exception cref="SecurityException">The caller does not have the required permission.</exception>
    /// <exception cref="ArgumentException">
    ///     .NET Framework and .NET Core versions older than 2.1: path is an empty string (""), contains
    ///     only white space, or contains one or more invalid characters.
    ///     -or-
    ///     path refers to a non-file device, such as "con:", "com1:", "lpt1:", etc. in an NTFS
    ///     environment.
    /// </exception>
    /// <exception cref="NotSupportedException">
    ///     path refers to a non-file device, such as "con:", "com1:",
    ///     "lpt1:", etc. in a non-NTFS environment.
    /// </exception>
    /// <exception cref="ArgumentNullException">Parameter path in editorconfig file is <see langword="null" />.</exception>
    /// <exception cref="PathTooLongException">The specified path, file name, or both exceed the system-defined maximum length.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Parameter mode contains an invalid value.</exception>
    /// <exception cref="IOException">An I/O error occurs.</exception>
    /// <exception cref="ObjectDisposedException">Methods were called after the stream was closed.</exception>
    /// <exception cref="FileNotFoundException">
    ///     The file cannot be found, such as when mode is
    ///     <see langword="FileMode.Truncate" /> or <see langword="FileMode.Open" />, and the file specified by
    ///     path does not exist. The file must already exist in these modes.
    /// </exception>
    /// <exception cref="UnauthorizedAccessException">Path for editorconfig specifies a file that is read-only.</exception>
    /// <exception cref="DirectoryNotFoundException">The specified path is invalid, such as being on an unmapped drive.</exception>
    public async Task ExecuteAsync(EditorConfigFile editorConfigFile)
    {
        using var fileStream = fileSystem.FileStream.New(editorConfigFile.FilePath, FileMode.Open);
        var fileHash = fileStream.ToMD5HashString();
        if (editorConfigFile.FilePath == fileHash)
        {
            logger.LogInformation("File {FilePath} has not changed. Skipping processing", editorConfigFile.FilePath);

            return;
        }

        editorConfigFile.FileHash = fileHash;

        editorConfigFile.ConfigSections!.Clear();

        fileStream.Seek(0, SeekOrigin.Begin);
        IniFile? iniFile;
        try
        {
            iniFile = await IniFileParser.ParseAsync(fileStream);
        }
#pragma warning disable S2139 // Log and rethrow the exception - this is already logged
        catch (Exception ex)
#pragma warning restore S2139
        {
            logger.LogError(ex, "Error parsing file {FilePath}", editorConfigFile.FilePath);

            throw;
        }

        foreach (var iniFileSection in iniFile.Sections)
        {
            var configSection = new ConfigSection
                                {
                                    GlobPattern = iniFileSection.Key,
                                    ConfigEntries = [],
                                    Comments = [],
                                    Description = $"{iniFileSection.Key} description"
                                };
            editorConfigFile.ConfigSections!.Add(configSection);

            await sectionProcessor.ExecuteAsync(configSection, iniFileSection.Value);
        }
    }
}