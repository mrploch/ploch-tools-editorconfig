using Ploch.Data.GenericRepository;
using Ploch.EditorConfigTools.Models;
using Ploch.EditorConfigTools.Processing;

namespace Ploch.EditorConfigTools.UseCases;

public class AddNewOrUpdateProject(IReadWriteRepositoryAsync<Project, int> projectRepository, ProjectPathProcessor projectPathProcessor)
{
    public async Task ExecuteAsync(AddNewOrUpdateProjectSettings settings)
    {
        var project = await projectRepository.GetAsync(p => p.Name == settings.ProjectName && p.Path == settings.ProjectPath);

        if (project == null)
        {
            project = new Project
            {
                Name = settings.ProjectName,
                Description = settings.Description,
                Path = settings.ProjectPath ?? throw new InvalidOperationException("Project path must be provided."),
                EditorConfigFiles = new List<EditorConfigFile>()
            };

            await projectRepository.AddAsync(project);
        }
        else
        {
            project.Description = settings.Description;
            await projectRepository.UpdateAsync(project);
        }
        
        await projectPathProcessor.ExecuteAsync(project);
    }
}