using Microsoft.AspNetCore.Mvc;
using VendaLanches.Models;
using VendaLanches.Repositories.Interfaces;
using VendaLanches.ViewModels;

namespace VendaLanches.Controllers
{
    public class CarrinhoController : Controller 
    {   
        readonly ILancheRepository _lancheRepository;
        readonly ICarrinhoRepository _carrinhoRepository; 

        public CarrinhoController(ILancheRepository lancheRepository, ICarrinhoRepository carrinhoRepository) 
        {
            _lancheRepository = lancheRepository;
            _carrinhoRepository = carrinhoRepository;
        }

        public IActionResult Index() 
        {
            var pedidos = _carrinhoRepository.GetPedidosNoCarrinho();
            var total = _carrinhoRepository.GetTotalCompraCarrinho();

            var carrinhoCompraViewModel = new CarrinhoCompraViewModel {
                Carrinho = pedidos,
                Total = total 
            };

            return View(carrinhoCompraViewModel);
        }

        public RedirectToActionResult AdicionarItemNoCarrinhoCompra(int lancheId, int lancheQnt = 1) 
        {

            var lancheSelecionado = _lancheRepository.Lanches.SingleOrDefault(l => l.LancheId == lancheId);

          
            if (lancheSelecionado != null) 
            {
                
                Pedido novoPedido = new() {
                    Lanche = lancheSelecionado,
                    Quantidade = lancheQnt > 1 ? lancheQnt + 1 : 1,
                    LancheId = lancheId
                };

             _carrinhoRepository.AdicionarNoCarrinho(novoPedido);
            }
            
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoverDoCarrinho(int pedidoId) 
        {
            var removido = _carrinhoRepository.RemoverDoCarrinho(pedidoId);

            if (removido) 
            {
                TempData["Success"] = "Pedido removido";
            }
            else 
            {
                TempData["Failure"] = "Não foi possível efetuar essa operação";
            }

            return RedirectToAction("Index");
        }
    }
}