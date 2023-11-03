using VendaLanches.Models;

namespace VendaLanches.Repositories.Interfaces
{
    public interface IEntregaRepository 
    {   
        public Entrega CriarEntrega(Entrega entrega, IEnumerable<Pedido> pedidos);
    }
}