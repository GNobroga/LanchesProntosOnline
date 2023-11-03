using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using VendaLanches.Models;
using VendaLanches.Repositories.Interfaces;

namespace VendaLanches.Controllers
{
    public class EntregaController : Controller
    {

        readonly IEntregaRepository _entregaRepository;
        readonly ICarrinhoRepository _carrinhoRepository;

        public EntregaController(IEntregaRepository entregaRepository, ICarrinhoRepository carrinhoRepository)
        {
            _entregaRepository = entregaRepository;
            _carrinhoRepository = carrinhoRepository;
        }

        public IActionResult Checkout() 
        {

            if (_carrinhoRepository.GetPedidosNoCarrinho().Count > 0) 
            {
                return View();
            }

            return RedirectToAction("List", "Lanche");
        }

        [HttpPost]
        public ViewResult Checkout([FromForm] Entrega entrega) 
        {   
            if (!ModelState.IsValid) 
            {
                return View(entrega);
            }

            _entregaRepository.CriarEntrega(entrega, _carrinhoRepository.GetPedidosNoCarrinho());
           _carrinhoRepository.LimparCarrinho();
            return View();
        }
    }
}