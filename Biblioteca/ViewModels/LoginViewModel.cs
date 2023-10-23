using System.ComponentModel.DataAnnotations;

namespace Biblioteca.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "E-mail solicitado!!!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha solicitada!!!")]
        public string Senha { get; set; }
    }
}
