﻿using System.ComponentModel.DataAnnotations;

namespace Rasdoc.DTO.Models
{
    public record RegisterUserDTO
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo {0} está em formato inválido")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 6)]
        public string? Password { get; set; }

        [Compare("Password", ErrorMessage = "As senhas não conferem")]
        public string? ConfirmPassword { get; set; }
    }

    public record LoginUserDTO
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo {0} está em formato inválido")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 6)]
        public string? Password { get; set; }
    }

    public record UserTokenDTO
    {
        public string? Id { get; set; }
        public string? Email { get; set; }
        public IEnumerable<ClaimDTO>? Claims { get; set; }
    }

    public record LoginResponseDTO
    {
        public string? AccessToken { get; set; }
        public double ExpiresIn { get; set; }
        public UserTokenDTO? UserToken { get; set; }
    }

    public record ClaimDTO
    {
        public string? Value { get; set; }
        public string? Type { get; set; }
    }
}
