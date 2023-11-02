using VendaLanches.Data;
using VendaLanches.Models;
using VendaLanches.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace VendaLanches.Repositories
{
    public class LancheRepositoryImpl : ILancheRepository
    {
        
        public IEnumerable<Lanche> Lanches => _context.Lanches.Include(l => l.Categoria);

        readonly AppDbContext _context;

        public LancheRepositoryImpl(AppDbContext context) 
        {
            _context = context;
        }
        

        public List<Lanche> GetFavorites()
        {
            return _context.Lanches.Include(l => l.Categoria).Where(l => l.IsLanchePreferido).ToList();
        }
    }
}