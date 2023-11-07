using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using VendaLanches.Models;
using VendaLanches.Repositories.Interfaces;

namespace VendaLanches.Controllers
{
    public class HomeController : Controller
    {

        readonly ILancheRepository _lancheRepository;
        readonly UserManager<IdentityUser> _userManager;

        public HomeController(ILancheRepository lancheRepository, UserManager<IdentityUser> userManager) 
        {
            _lancheRepository = lancheRepository;
            _userManager = userManager;


        }
        public IActionResult Index()
        {
            var preferidos = _lancheRepository.GetFavorites();
            
            return View(preferidos);
        }

    }
}

