using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace VendaLanches.Models
{   
    [Table("Pedidos")]
    public class Pedido
    {
        [Key] 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PedidoId { get; set; }

        [ForeignKey("Lanche")]
        public int LancheId { get; set; }

        public Lanche Lanche { get; set; }

        public int Quantidade { get; set; }

        public string CarrinhoId { get; set; }
    }
}