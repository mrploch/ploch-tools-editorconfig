using System.IO.Abstractions;
using Ploch.EditorConfigTools.Models;

namespace Ploch.EditorConfigTools.Processing;
public class ProjectPathProcessor(IFileSystem fileSystem, EditorConfigFileProcessor fileProcessor)
{
    public Task ExecuteAsync(Project project)
    {
        var directoryInfo = fileSystem.DirectoryInfo.New(project.Path);

        if (!directoryInfo.Exists)
        {
            throw new DirectoryNotFoundException($"Directory {project.Path} does not exist.");
        }

        return ProcessPathAsync(directoryInfo, project);
    }

    private async Task ProcessPathAsync(IDirectoryInfo directoryInfo, Project project)
    {
        var editorConfigFile = directoryInfo.GetFiles(".editorconfig", SearchOption.TopDirectoryOnly).FirstOrDefault();

        if (editorConfigFile != null)
        {
            var file = project.EditorConfigFiles.FirstOrDefault(f => f.FilePath == editorConfigFile.FullName);
            if (file == null)
            {
                file = new EditorConfigFile
                       {
                           FilePath = editorConfigFile.FullName, Name = editorConfigFile.FullName, Project = project, ConfigSections = []
                       };
                project.EditorConfigFiles.Add(file);
            }

            await fileProcessor.ExecuteAsync(file);
        }

        foreach (var subDirectory in directoryInfo.GetDirectories())
        {
            await ProcessPathAsync(subDirectory, project);
        }
    }
}
