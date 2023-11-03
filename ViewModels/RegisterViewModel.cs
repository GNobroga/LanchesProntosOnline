using System.ComponentModel.DataAnnotations;

namespace VendaLanches.ViewModels
{
    public class RegisterViewModel 
    {
        [Required(ErrorMessage = "Informe o nome")]
        [Display(Name = "Usuário")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Informe o email")]
        [Display(Name = "E-mail")]
        public string Email{ get; set; }

        [Required(ErrorMessage = "Informe a senha")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Informe a senha de confirmação")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha de Confirmação")]
        [Compare("Password", ErrorMessage = "As senhas não correspondem")]
        public string PasswordConfirmation { get; set; }
    }
}