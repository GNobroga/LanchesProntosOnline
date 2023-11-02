using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VendaLanches.Models 
{   
    [Table("Categorias")]
    public class Categoria 
    {   
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoriaId { get; set; }

        [StringLength(100, ErrorMessage = "O tamanho máximo é 100 caracteres.")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Categoria")]
        public string CategoriaNome { get; set; }

        [StringLength(200, ErrorMessage = "O tamanho máximo é 100 caracteres.")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Descrição da Categoria")]
        public string CategoriaDescricao { get; set; }

        public ICollection<Lanche> Lanches { get; set; }
    }
}