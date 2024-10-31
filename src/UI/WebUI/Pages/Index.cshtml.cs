using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Ploch.EditorConfigTools.Models;

namespace Ploch.EditorConfigTools.UI.WebUI.Pages;

public class IndexModel(UserManager<ApplicationUser> userManager, ILogger<IndexModel> logger) : PageModel
{
    public IEnumerable<Project>? UserProjects { get; set; }

    public void OnGet()
    {
        var userId = userManager.GetUserId(User);
        var applicationUser = userManager.Users.FirstOrDefault(u => u.Id == userId);

        if (applicationUser.Projects != null)
        {
            UserProjects = applicationUser.Projects;
        }
    }
}