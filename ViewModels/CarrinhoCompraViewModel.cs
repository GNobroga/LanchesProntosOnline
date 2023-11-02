using System.Xml.Schema;
using VendaLanches.Models;

namespace VendaLanches.ViewModels
{
    public class CarrinhoCompraViewModel 
    {
        public List<Pedido> Carrinho { get; set; }
        
        public decimal Total { get; set; }
    }
}