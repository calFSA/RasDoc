using System.ComponentModel.DataAnnotations;

namespace Rasdoc.DTO.Models
{
    public record ProjetoDTO
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string? Apelido { get; set; }

        public bool Ativo { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime IniciadoEm { get; set; }
        public DateTime? FinalizadoEm { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid EquipeId { get; set; }
        public EquipeDTO? Equipe { get; set; }

        public ICollection<ProjetoColaboradorDTO>? ProjetosColaborador { get; set; }
    }
}
