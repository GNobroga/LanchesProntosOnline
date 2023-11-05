using VendaLanches.Data;
using VendaLanches.Models;
using VendaLanches.Repositories.Interfaces;

namespace VendaLanches.Repositories
{
    public class CategoriaRepositoryImpl : ICategoriaRepository
    {
        public IEnumerable<Categoria> Categorias => _context.Categorias.Where(c => !c.SoftDelete);

        readonly AppDbContext _context;

        public CategoriaRepositoryImpl(AppDbContext context) 
        {
            _context = context;
        }
    }
}