using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using VendaLanches.ViewModels;

namespace VendaLanches.Controllers
{
    public class AccountController : Controller
    {
        readonly UserManager<IdentityUser> _userManager;
        readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public ViewResult Login() 
        {   
            var returnUrl = HttpContext.Request.Query["ReturnUrl"].ToString();
            return View(new LoginViewModel {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromForm] LoginViewModel loginViewModel) 
        {

            if (!ModelState.IsValid) return View(loginViewModel);
        

            var user = await _userManager.FindByNameAsync(loginViewModel.Username);

            if (user == null) 
            {   
                TempData["Error"] = "Usuário ou senha inválidos";
                return View(loginViewModel);
            }

            var authentication = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false);

            if (authentication.Succeeded) 
            {
                if (loginViewModel.ReturnUrl != null) 
                {
                  return Redirect(loginViewModel.ReturnUrl);
                }
                return RedirectToAction("Index", "Home");
            }

            
            TempData["Error"] = "Usuário ou senha inválidos";
            return RedirectToAction("Login");
        }

        public IActionResult Register() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromForm] RegisterViewModel registerViewModel) 
        {
            if (!ModelState.IsValid) return View(registerViewModel);
            
            IdentityUser newUser = new() { 
                UserName = registerViewModel.Username,
                Email = registerViewModel.Email
            };

            var result = await _userManager.CreateAsync(newUser, registerViewModel.Password);

            if (result.Succeeded) 
            {
                await _userManager.AddToRoleAsync(newUser, "Member");
                TempData["Success"] = "Conta criada com sucesso";
                return RedirectToAction("Register");
            }

            foreach (var error in result.Errors) 
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(registerViewModel);
        }

        public async Task<IActionResult> Logout() 
        {
            if (_signInManager.IsSignedIn(User)) 
            {
                await _signInManager.SignOutAsync();
            }
  
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AccessDenied() 
        {
            return View();
        }
    }
}