using Ploch.Data.GenericRepository;
using Ploch.EditorConfigTools.Models;
using Ploch.EditorConfigTools.Processing;

namespace Ploch.EditorConfigTools.UseCases;
public class AddEditorConfigFile(IUnitOfWork unitOfWork, EditorConfigFileProcessor configFileProcessor) : IUseCase<AddEditorConfigFileSettings>
{
    public async Task ExecuteAsync(AddEditorConfigFileSettings settings, CancellationToken cancellationToken = default)
    {
        var project = await unitOfWork.Repository<Project, int>().GetByIdAsync(settings.ProjectId, cancellationToken: cancellationToken);

        if (project == null)
        {
            throw new InvalidOperationException($"Project with id {settings.ProjectId} not found.");
        }

        var editorConfigFile =
            new EditorConfigFile { Name = settings.FileName, FilePath = settings.FileName, Project = project, ConfigSections = [] };
        await configFileProcessor.ExecuteAsync(editorConfigFile, settings.FileStream, cancellationToken);
        project.EditorConfigFiles.Add(editorConfigFile);
        await unitOfWork.CommitAsync(cancellationToken);
    }
}
