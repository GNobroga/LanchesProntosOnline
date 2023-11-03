using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace  VendaLanches.Models
{
    [Table("Entregas")]
    public class Entrega 
    {
        public int EntregaId { get; set; }
        
        [StringLength(50, ErrorMessage = "Tamanho máximo de 50 caracteres")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Nome*")]
        public string Nome { get; set; }

        [StringLength(50, ErrorMessage = "Tamanho máximo de 50 caracteres")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Sobrenome*")]
        public string Sobrenome { get; set; }

        [StringLength(100, ErrorMessage = "Tamanho máximo de 50 caracteres")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Endereco*")]
        public string Endereco { get; set; }
        
        [StringLength(10, ErrorMessage = "Tamanho máximo de 10 caracteres")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Estado*")]
        public string Estado { get; set; }

        [StringLength(50, ErrorMessage = "Tamanho máximo de 50 caracteres")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Cidade*")]
        public string Cidade { get; set; }

        [StringLength(25, ErrorMessage = "Tamanho máximo de 25 caracteres")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telefone*")]
        public string Telefone { get; set; }

        [StringLength(50, ErrorMessage = "Tamanho máximo de 50 caracteres")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [EmailAddress]
        [Display(Name = "Email*")]
        public string Email { get; set; }

        public decimal PedidoTotal { get; set; }

        public int QntPedidos { get; set; }

        [Display(Name = "Data do Pedido")]
        [DataType(DataType.Text)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime PedidoEnviado { get; set; } = new DateTime();

        [Display(Name = "Data Envio Pedido")]
        [DataType(DataType.Text)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime PedidoEntregueEm { get; set; }

        public ICollection<Pedido> Pedidos { get; set; }
    }
}