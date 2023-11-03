using VendaLanches.Data;
using VendaLanches.Models;
using VendaLanches.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.ObjectPool;
namespace VendaLanches.Repositories
{
    public class EntregaRepositoryImpl : IEntregaRepository
    {
        readonly AppDbContext _context;

        public EntregaRepositoryImpl(AppDbContext context) => _context = context;

        public void CriarEntrega(Entrega entrega, IEnumerable<Pedido> pedidos)
        {   
            _context.Entregas.Add(entrega);
            _context.SaveChanges();

            Entrega savedEntrega = _context.Entregas.OrderBy(e => e.EntregaId).Last();
            decimal pedidoTotal = 0;
            int qntPedidos = 0;

            foreach (Pedido p in pedidos) 
            {
                p.EntregaId = savedEntrega.EntregaId;
                _context.Entry(p).State = EntityState.Modified;
                pedidoTotal += p.Quantidade * p.Lanche.Preco;
                qntPedidos += p.Quantidade;
            }

            savedEntrega.QntPedidos = qntPedidos;
            savedEntrega.PedidoTotal = pedidoTotal;
            savedEntrega.PedidoEnviado = DateTime.Now.ToUniversalTime();

            _context.SaveChanges();
        }
    }
}