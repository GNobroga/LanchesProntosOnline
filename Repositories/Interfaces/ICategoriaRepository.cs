using VendaLanches.Data;
using VendaLanches.Models;

namespace VendaLanches.Repositories.Interfaces
{
    public interface ICategoriaRepository 
    {
        public IEnumerable<Categoria> Categorias { get; }

    }
}