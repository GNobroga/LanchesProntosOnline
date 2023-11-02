using Microsoft.AspNetCore.Mvc;
using VendaLanches.Repositories.Interfaces;

namespace VendaLanches.Components
{
    public class CarrinhoBadge : ViewComponent
    {   
        readonly ICarrinhoRepository _carrinhoRepository;

        public CarrinhoBadge(ICarrinhoRepository carrinhoRepository) 
        {
            _carrinhoRepository = carrinhoRepository;
        }

        public IViewComponentResult Invoke() 
        {
        
            return View(_carrinhoRepository.GetPedidosNoCarrinho().Count());
        }
    }
}