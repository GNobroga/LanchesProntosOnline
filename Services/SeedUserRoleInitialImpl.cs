using Microsoft.AspNetCore.Identity;
using VendaLanches.Services.interfaces;

namespace VendaLanches.Services
{
    public class SeedUserRoleInitialImpl : ISeedUserRoleInitial
    {
        readonly UserManager<IdentityUser> _userManager;
        readonly RoleManager<IdentityRole> _roleManager;

        public SeedUserRoleInitialImpl(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        
        public void SeedRoles()
        {
            Console.WriteLine("Fui executado");
           if (!_roleManager.Roles.Any(r => r.Name.Equals("Member")))
           {
             IdentityRole role = new("Member");
             _roleManager.CreateAsync(role).Wait();
           }

            if (!_roleManager.Roles.Any(r => r.Name.Equals("Admin")))
            {
                IdentityRole role = new("Admin");
                _roleManager.CreateAsync(role).Wait();
            }
        }

        public  void SeedUsers()
        {   
           PopulateUser().Wait();
        }

        private async Task PopulateUser() 
        {
            try
            {
                if (await _userManager.FindByEmailAsync("admin@admin.com") == null)
                {   
                    IdentityUser user = new("Gabrielcar34")
                    {
                        Email = "admin@admin.com",
                        LockoutEnabled = false,
                        EmailConfirmed = true
                    };

                    IdentityResult result = await _userManager.CreateAsync(user, "Gabrielcar34@");

                    if (result.Succeeded) 
                    {

                        await _userManager.AddToRoleAsync(user, "ADMIN");
                    }
                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro: {ex}");
            }
        }
    }
}