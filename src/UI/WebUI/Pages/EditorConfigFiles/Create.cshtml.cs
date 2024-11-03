using Microsoft.AspNetCore.Mvc;
using Ploch.EditorConfigTools.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Ploch.Data.GenericRepository.EFCore;

namespace Ploch.EditorConfigTools.UI.WebUI.Pages.EditorConfigFiles;
public class CreateModel(UnitOfWork unitOfWork) : PageModel
{
    [BindProperty]
    public EditorConfigFile EditorConfigFile { get; set; } = default!;

    public IActionResult OnGet()
    {
        return Page();
    }

    // For more information, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync(CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        await unitOfWork.Repository<EditorConfigFile, int>().AddAsync(EditorConfigFile, cancellationToken);

        await unitOfWork.CommitAsync(cancellationToken);

        return RedirectToPage("./Index");
    }
}
