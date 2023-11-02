using VendaLanches.Models;

namespace VendaLanches.Repositories.Interfaces
{
    public interface ILancheRepository 
    {
        public IEnumerable<Lanche> Lanches { get; }

        public List<Lanche> GetFavorites();

    }
}