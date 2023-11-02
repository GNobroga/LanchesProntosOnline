using VendaLanches.Models;

namespace VendaLanches.Repositories.Interfaces
{
    public interface ICarrinhoRepository 
    {

        public void AdicionarNoCarrinho(Pedido pedido);

        public bool RemoverDoCarrinho(int pedidoId);
        public List<Pedido> GetPedidosNoCarrinho();

        public  void LimparCarrinho();

        public decimal GetTotalCompraCarrinho();
    }
}