using System.ComponentModel.DataAnnotations;

namespace MatrizDeRastreabilidade.API.Models.DTO
{
    public class UsuarioDTO
    {
        [Required(ErrorMessage = "O nome deve ser informado")]
        public string Nome { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string EMail { get; set; }

        [Required(ErrorMessage = "A senha deve ser informada")]
        public string Senha { get; set; }

        [Required]
        [Compare("Senha", ErrorMessage = "As senhas não correspondem")]
        public string ConfirmarSenha { get; set; }
    }
}
