using Microsoft.AspNetCore.Mvc;
using Ploch.Data.GenericRepository;
using Ploch.EditorConfigTools.Models;
using Ploch.EditorConfigTools.UseCases;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Ploch.EditorConfigTools.UI.WebUI.Pages.EditorConfigFiles;
public class IndexModel(IReadRepositoryAsync<EditorConfigFile, int> editorConfigFileRepository,
                        IUnitOfWork unitOfWork,
                        AddEditorConfigFile addEditorConfigFile) : PageModel
{
    public IList<EditorConfigFile> EditorConfigFiles { get; set; } = default!;

    [BindProperty]
    [FromForm]
    public int ProjectId { get; set; }

    [BindProperty]
    [FromForm]
    public IFormFile? FileUpload { get; set; }

    public async Task OnGetAsync(int projectId)
    {
        ProjectId = projectId;
        EditorConfigFiles = await editorConfigFileRepository.GetPageAsync(1, 10, f => f.Project.Id == projectId);
    }

    public async Task<IActionResult> OnPostUploadAsync(IFormFile file, CancellationToken cancellationToken)
    {
        using var stream = FileUpload.OpenReadStream();
        await addEditorConfigFile.ExecuteAsync(new AddEditorConfigFileSettings(ProjectId, FileUpload.FileName, stream), cancellationToken);

        // var size = files.Sum(f => f.Length);
        //
        // foreach (var formFile in files)
        // {
        //     if (formFile.Length > 0)
        //     {
        //         var filePath = Path.GetTempFileName();
        //
        //         using (var stream = System.IO.File.Create(filePath))
        //         {
        //             await formFile.CopyToAsync(stream);
        //         }
        //     }
        // }

        // Process uploaded files
        // Don't rely on or trust the FileName property without validation.

        return RedirectToPage("./Index", new { projectId = ProjectId });
    }
}

public class BufferedSingleFileUploadDb
{
    [Required]
    [Display(Name = "File")]
    public IFormFile? FormFile { get; set; }
}
