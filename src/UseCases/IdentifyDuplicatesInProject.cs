using Ploch.Data.GenericRepository;
using Ploch.EditorConfigTools.Models;

namespace Ploch.EditorConfigTools.UseCases;
public record IdentifyDuplicatesInProjectSettirngs(int ProjectId);

public class IdentifyDuplicatesInProject(IReadRepositoryAsync<Project, int> projectRepository,
                                         IReadRepositoryAsync<ConfigEntry, int> configEntryRepository)
    : IUseCase<IdentifyDuplicatesInProjectSettirngs>
{
    public async Task ExecuteAsync(IdentifyDuplicatesInProjectSettirngs settings, CancellationToken cancellationToken = default)
    {
        var project = await projectRepository.GetByIdAsync([settings.ProjectId]);

        if (project == null)
        {
            throw new InvalidOperationException("Project not found.");
        }

        foreach (var editorConfigFile in project.EditorConfigFiles)
        {
            var configSections = editorConfigFile.ConfigSections;

            foreach (var configSection in configSections)
            {
                var grouppedEntries = configSection.ConfigEntries.GroupBy(ce => ce.Name);

                var dupes = grouppedEntries.Where(g => g.Count() > 1);

                foreach (var configEntries in dupes)
                {
                    Console.WriteLine($"Duplicate entries for {configEntries.Key} in {configSection.GlobPattern} in {editorConfigFile.FilePath}");
                }
            }
        }
    }
}
