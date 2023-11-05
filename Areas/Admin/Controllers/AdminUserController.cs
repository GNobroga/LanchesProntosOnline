using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace VendaLanches.Areas.Admin.Controllers
{   
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminUserController : Controller
    {

        readonly UserManager<IdentityUser> _userManager;

        public AdminUserController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> List() 
        {   
           var users = await _userManager.GetUsersInRoleAsync("Member");

            return View(users);
        }
    }
}