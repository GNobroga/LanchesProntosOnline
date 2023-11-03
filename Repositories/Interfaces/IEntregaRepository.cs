using VendaLanches.Models;

namespace VendaLanches.Repositories.Interfaces
{
    public interface IEntregaRepository 
    {
        public void CriarEntrega(Entrega entrega, IEnumerable<Pedido> pedidos);
    }
}