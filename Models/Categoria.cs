using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace VendaLanches.Models 
{   
    [Table("Categorias")]
    public class Categoria 
    {   
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [HiddenInput]
        public int CategoriaId { get; set; }

        [StringLength(100, ErrorMessage = "O tamanho máximo é 100 caracteres.")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Nome")]
        public string CategoriaNome { get; set; }

        [StringLength(200, ErrorMessage = "O tamanho máximo é 100 caracteres.")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Descrição da Categoria")]
        public string CategoriaDescricao { get; set; }

        public ICollection<Lanche> Lanches { get; set; }

        public bool SoftDelete { get; set; }
    }
}