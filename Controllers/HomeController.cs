using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using VendaLanches.Models;
using VendaLanches.Repositories.Interfaces;

namespace VendaLanches.Controllers
{
    public class HomeController : Controller
    {

        readonly ILancheRepository _lancheRepository;

        public HomeController(ILancheRepository lancheRepository) 
        {
            _lancheRepository = lancheRepository;
        }
        public IActionResult Index()
        {
            var preferidos = _lancheRepository.GetFavorites();
            
            return View(preferidos);
        }

    }
}

