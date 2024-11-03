using Microsoft.AspNetCore.Mvc;
using Ploch.Data.GenericRepository;
using Ploch.EditorConfigTools.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Ploch.EditorConfigTools.UI.WebUI.Models;

namespace Ploch.EditorConfigTools.UI.WebUI.Pages.EditorConfigFiles;
public class DetailsModel(IReadRepositoryAsync<EditorConfigFile, int> editorConfigFileRepository) : PageModel
{
    public EditorConfigFile EditorConfigFile { get; set; } = default!;

    public IEnumerable<ConfigEntryModel> AllConfigEntries { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id, CancellationToken cancellationToken)
    {
        if (id == null)
        {
            return NotFound();
        }

        var edditorConfigFile = await editorConfigFileRepository.GetByIdAsync(id.Value, cancellationToken: cancellationToken);

        if (edditorConfigFile == null)
        {
            return NotFound();
        }

        EditorConfigFile = edditorConfigFile;

        AllConfigEntries = edditorConfigFile.ConfigSections!.SelectMany(c => c.ConfigEntries!).Select(entry => entry.ToModel());
        return Page();
    }
}
