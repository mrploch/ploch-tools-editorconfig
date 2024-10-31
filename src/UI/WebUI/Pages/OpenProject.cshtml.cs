using Microsoft.AspNetCore.Mvc.RazorPages;
using Ploch.Data.GenericRepository;
using Ploch.EditorConfigTools.Models;

namespace Ploch.EditorConfigTools.UI.WebUI.Pages;

public class OpenProject(IReadRepositoryAsync<Project, int> projectRepository) : PageModel
{
    public Project Project { get; set; } = null!;
    
    public IEnumerable<EditorConfigFile>? EditorConfigFiles { get; set; }

    public async Task OnGetAsync(int projectId, CancellationToken cancellationToken)
    {
        Project = await projectRepository.GetByIdAsync(projectId, cancellationToken: cancellationToken) ??
                  throw new InvalidOperationException($"Project with id {projectId} not found");
        
        if (Project.EditorConfigFiles != null)
        {
            EditorConfigFiles = Project.EditorConfigFiles;
        }
    }
}