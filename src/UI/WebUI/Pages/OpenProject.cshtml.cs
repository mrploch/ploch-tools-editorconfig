using Ploch.Data.GenericRepository;
using Ploch.EditorConfigTools.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Ploch.EditorConfigTools.UI.WebUI.Models;

namespace Ploch.EditorConfigTools.UI.WebUI.Pages;
public class OpenProject(IReadRepositoryAsync<Project, int> projectRepository,
                         IReadRepositoryAsync<EditorConfigFile, int> editorConfigFileRepository)
    : PageModel
{
    public Project Project { get; set; } = null!;

    public IEnumerable<EditorConfigFileModel>? EditorConfigFiles { get; set; }

    public EditorConfigFile? EditorConfigFileDetails { get; set; }

    public async Task OnGetAsync(int projectId, CancellationToken cancellationToken)
    {
        await PopulateEditorConfigFiles(projectId, cancellationToken);
    }

    public async Task OnGetDetails(int editorConfigFileId, int projectId, CancellationToken cancellationToken)
    {
        var editorConfigFile = await editorConfigFileRepository.GetByIdAsync(editorConfigFileId, cancellationToken: cancellationToken) ??
                               throw new InvalidOperationException($"EditorConfigFile with id {editorConfigFileId} not found");

        EditorConfigFileDetails = editorConfigFile;

        await PopulateEditorConfigFiles(projectId, cancellationToken);
    }

    private async Task PopulateEditorConfigFiles(int projectId, CancellationToken cancellationToken)
    {
        var project = await projectRepository.GetByIdAsync(projectId, cancellationToken: cancellationToken) ??
                      throw new InvalidOperationException($"Project with id {projectId} not found");
        Project = project;

        if (project.EditorConfigFiles != null)
        {
            EditorConfigFiles =
                project.EditorConfigFiles.Select(f => f.ToModel());
        }
    }
}
