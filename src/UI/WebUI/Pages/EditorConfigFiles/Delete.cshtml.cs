using Microsoft.AspNetCore.Mvc;
using Ploch.Data.GenericRepository;
using Ploch.EditorConfigTools.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ploch.EditorConfigTools.UI.WebUI.Pages.EditorConfigFiles;
public class DeleteModel(IUnitOfWork unitOfWork) : PageModel
{
    [BindProperty]
    public EditorConfigFile EditorConfigFile { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int id, CancellationToken cancellationToken)
    {
        var editorConfigFile = await unitOfWork.Repository<EditorConfigFile, int>().GetByIdAsync(id, cancellationToken: cancellationToken);

        if (editorConfigFile == null)
        {
            return NotFound();
        }

        EditorConfigFile = editorConfigFile;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int id, CancellationToken cancellationToken)
    {
        var repository = unitOfWork.Repository<EditorConfigFile, int>();
        var editorConfigFile = await repository.GetByIdAsync(id, cancellationToken: cancellationToken);
        if (editorConfigFile != null)
        {
            EditorConfigFile = editorConfigFile;
            await repository.DeleteAsync(EditorConfigFile, cancellationToken);

            await unitOfWork.CommitAsync(cancellationToken);
        }

        return RedirectToPage("./Index", new { projectId = editorConfigFile.Project.Id });
    }
}