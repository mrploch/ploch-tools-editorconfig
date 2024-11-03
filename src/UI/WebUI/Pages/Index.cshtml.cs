using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Ploch.EditorConfigTools.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ploch.EditorConfigTools.UI.WebUI.Pages;
public class IndexModel(UserManager<ApplicationUser> userManager, ILogger<IndexModel> logger) : PageModel
{
    public IEnumerable<Project>? UserProjects { get; set; }

    public async Task OnGetAsync()
    {
        var userId = userManager.GetUserId(User);
        if (userId == null)
        {
            logger.LogTrace("User not logged in");

            return;
        }

        var applicationUser = await userManager.Users.FirstOrDefaultAsync(u => u.Id == userId);

        if (applicationUser?.Projects != null)
        {
            UserProjects = applicationUser.Projects;
        }
    }

    public async Task OnGetButtonClick()
    {
        logger.LogInformation("Button clicked");
    }
}