using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace VendaLanches.ViewModels
{
    public class LoginViewModel 
    {
        [Required(ErrorMessage = "Informe o nome")]
        [Display(Name = "Usuário")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Informe a senha")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [HiddenInput]
        public string ReturnUrl { get; set; }
    }
}