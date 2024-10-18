using System.IO.Abstractions;
using Ploch.EditorConfigTools.Models;

namespace Ploch.EditorConfigTools.Processing;

public class ProjectPathProcessor(IFileSystem fileSystem, EditorConfigFileProcessor fileProcessor)
{
    public async Task ExecuteAsync(Project project)
    {
        var directoryInfo = fileSystem.DirectoryInfo.New(project.Path);

        if (!directoryInfo.Exists)
        {
            throw new DirectoryNotFoundException($"Directory {project.Path} does not exist.");
        }

        await ProcessPathAsync(directoryInfo, project);
    }

    private async Task ProcessPathAsync(IDirectoryInfo directoryInfo, Project project)
    {
        var editorConfigFile = directoryInfo.GetFiles("*.editorconfig", SearchOption.TopDirectoryOnly).FirstOrDefault();

        if (editorConfigFile != null)
        {
            var file = new EditorConfigFile { FilePath = editorConfigFile.FullName, Name = editorConfigFile.FullName, Project = project };

            project.EditorConfigFiles.Add(file);

            await fileProcessor.ExecuteAsync(file);
        }

        var directories = directoryInfo.GetDirectories();

        foreach (var subDirectory in directories)
        {
            ProcessPathAsync(subDirectory, project);
        }
    }
}