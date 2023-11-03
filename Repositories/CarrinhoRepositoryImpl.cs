using Microsoft.EntityFrameworkCore;
using VendaLanches.Data;
using VendaLanches.Models;
using VendaLanches.Repositories.Interfaces;

namespace VendaLanches.Repositories
{
    public class CarrinhoRepositoryImpl : ICarrinhoRepository
    {
        readonly AppDbContext _context;

        readonly ISession _session;

        private const string SESSION_KEY = "CarrinhoId";
        
        private readonly string _carrinhoId;

        public CarrinhoRepositoryImpl(AppDbContext context, IHttpContextAccessor contextAccessor) 
        {
            _context = context;
            _session = contextAccessor.HttpContext.Session;
            
            _carrinhoId = _session.GetString(SESSION_KEY);

            if (_carrinhoId == null) 
            {
                _carrinhoId = Guid.NewGuid().ToString();
                _session.SetString(SESSION_KEY, _carrinhoId);
            }

        }

        public void AdicionarNoCarrinho(Pedido pedido) 
        {   
            if (_context.Pedidos.Any(p => p.LancheId == pedido.LancheId && p.CarrinhoId == _carrinhoId))
            {
                var pedidoEncontrado = _context.Pedidos.Single(p => p.LancheId == pedido.LancheId && p.CarrinhoId == _carrinhoId);
                pedidoEncontrado.Quantidade += pedido.Quantidade;
            }
            else 
            {
                pedido.CarrinhoId = _carrinhoId;
                _context.Pedidos.Add(pedido);
            }
 
            _context.SaveChanges();
        }

        public bool RemoverDoCarrinho(int pedidoId) 
        {
            var deleted = _context.Pedidos.SingleOrDefault(p => p.PedidoId == pedidoId);

            if (deleted != null) 
            {
                _context.Remove(deleted);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Pedido> GetPedidosNoCarrinho() => _context.Pedidos.Where(p => p.CarrinhoId == _carrinhoId).Include(p => p.Lanche).ToList();
        

        public void LimparCarrinho() 
        {
            var pedidos = _context.Pedidos.Where(p => p.CarrinhoId == _carrinhoId);

            foreach (var p in pedidos) 
            {
                _context.Entry(p).State = EntityState.Deleted;
            }
            
            _context.SaveChanges();
        }

        public decimal GetTotalCompraCarrinho() => _context.Pedidos
                .Where(p => p.CarrinhoId == _carrinhoId)
                .Include(p => p.Lanche)
                .Select(p => p.Quantidade * p.Lanche.Preco)
                .Sum();
    }
}