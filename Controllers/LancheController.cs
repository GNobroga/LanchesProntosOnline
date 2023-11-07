using System.Data.Entity.Core.Common.CommandTrees;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VendaLanches.Repositories.Interfaces;
using VendaLanches.ViewModels;

namespace VendaLanches.Controllers
{
    [Authorize]
    public class LancheController : Controller
    {
        readonly ILancheRepository _repository;
        readonly ICategoriaRepository _categoriaRepository;

        public LancheController(ILancheRepository repository, ICategoriaRepository categoriaRepository) 
        {
            _repository = repository;
            _categoriaRepository = categoriaRepository;
        }

        public IActionResult List(int cid = -1, int size = 2, int page = 1, int limit = 2) 
        {   
            var lanchesListViewModel = new LancheListViewModel { 
                Lanches = _repository.Lanches.OrderBy(l => l.LancheId).Where(l => cid == -1 || l.CategoriaId == cid).Skip(size * (page - 1)).Take(limit), 
                Categorias = _categoriaRepository.Categorias,
                CategoriaSelecionada = cid 
            };
            return View(lanchesListViewModel);
        }

        public IActionResult Details(int lancheId = default, int lancheQnt = 1) 
        {   

            lancheQnt = lancheQnt < 1 ? 1 : lancheQnt;
        
            var lanche = _repository.Lanches.Where(l => l.LancheId == lancheId).FirstOrDefault();

            var lancheDetailsViewModel = new LancheDetailsViewModel { Lanche = lanche, Quantidade = lancheQnt };

            return View(lancheDetailsViewModel);
        }

        public IActionResult Search(string searchString) 
        {
            var lanchesListViewModel = new LancheListViewModel { 
                Lanches =  _repository.Lanches.Where(l => string.IsNullOrEmpty(searchString) || l.Nome.ToLower().Contains(searchString.ToLower())).OrderBy(l => l.LancheId),
                Categorias = _categoriaRepository.Categorias,
                CategoriaSelecionada = -1
            };

            return View("List", lanchesListViewModel);
        }
    }
}