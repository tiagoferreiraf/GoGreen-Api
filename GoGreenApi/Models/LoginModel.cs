using System.ComponentModel.DataAnnotations;

namespace GoGreenApi.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Digite o email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Digite a senha")]
        public string Senha { get; set; }
    }
}
