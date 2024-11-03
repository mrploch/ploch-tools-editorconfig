using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Ploch.EditorConfigTools.Models;

public class ApplicationUser : IdentityUser
{
    public virtual ICollection<Project>? Projects { get; set; }
}
