using VendaLanches.Models;

namespace VendaLanches.ViewModels
{
    public class LancheListViewModel
    {
        public IEnumerable<Lanche> Lanches { get; set; }

        public IEnumerable<Categoria> Categorias { get; set; }

        public int CategoriaSelecionada { get; set; }
    }
}