using Microsoft.AspNetCore.Mvc;
using Ploch.Data.GenericRepository;
using Microsoft.EntityFrameworkCore;
using Ploch.EditorConfigTools.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Ploch.EditorConfigTools.UI.WebUI.Models;

namespace Ploch.EditorConfigTools.UI.WebUI.Pages.EditorConfigFiles;
public class EditModel(IUnitOfWork unitOfWork, ILogger<EditModel> logger) : PageModel
{
    [BindProperty]
    public EditorConfigFileModel EditorConfigFile { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int id, CancellationToken cancellationToken)
    {
        var repository = unitOfWork.Repository<EditorConfigFile, int>();
        var editorConfigFile = await repository.GetByIdAsync(id, cancellationToken: cancellationToken);
        if (editorConfigFile == null)
        {
            return NotFound();
        }

        EditorConfigFile = editorConfigFile.ToModel();

        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more information, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync(CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var entity = await unitOfWork.Repository<EditorConfigFile, int>().GetByIdAsync(EditorConfigFile.Id);
        if (entity == null)
        {
            return NotFound();
        }

        EditorConfigFile.UpdateDataModel(entity);
        await unitOfWork.Repository<EditorConfigFile, int>().UpdateAsync(entity, cancellationToken);

        try
        {
            await unitOfWork.CommitAsync(cancellationToken);
        }
        catch (DbUpdateConcurrencyException ex)
        {
            logger.LogError(ex, "Failed to update EditorConfigFile {EditorConfigFileId}", EditorConfigFile.Id);
            throw;
        }

        return RedirectToPage("./Index", new { projectId = entity.Project.Id });
    }

    private async Task<bool> EditorConfigFileExistsAsync(int id)
    {
        return await unitOfWork.Repository<EditorConfigFile, int>().GetByIdAsync(id) != null;
    }
}
