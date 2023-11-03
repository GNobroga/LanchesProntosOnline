using Microsoft.AspNetCore.Mvc;
using VendaLanches.Repositories.Interfaces;
using VendaLanches.ViewModels;

namespace VendaLanches.Controllers
{
    public class LancheController : Controller
    {

        readonly ILancheRepository _repository;
        readonly ICategoriaRepository _categoriaRepository;

        public LancheController(ILancheRepository repository, ICategoriaRepository categoriaRepository) 
        {
            _repository = repository;
            _categoriaRepository = categoriaRepository;
        }

        public IActionResult List(int? cid) 
        {   
            var lanchesListViewModel = new LancheListViewModel { 
                Lanches = _repository.Lanches.OrderBy(l => l.LancheId), 
                Categorias = _categoriaRepository.Categorias 
            };

            int categoriaId = -1;

            if (cid.HasValue)
            {
                categoriaId = cid.Value;

                if (_categoriaRepository.Categorias.Any(c => c.CategoriaId == categoriaId)) 
                {
                    lanchesListViewModel.CategoriaSelecionada = categoriaId;
                } 
            } 
         
    
            lanchesListViewModel.CategoriaSelecionada = categoriaId;

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
                Lanches =  _repository.Lanches.Where(l => string.IsNullOrEmpty(searchString) || l.Nome.Contains(searchString)).OrderBy(l => l.LancheId),
                Categorias = _categoriaRepository.Categorias,
                CategoriaSelecionada = -1
            };

            return View("List", lanchesListViewModel);
        }
    }
}