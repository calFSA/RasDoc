using System.ComponentModel.DataAnnotations;

namespace Rasdoc.DTO.Models
{
    public class EquipeDTO
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public bool Ativo { get; set; } = true;

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime IniciadoEm { get; set; }
        public DateTime? FinalizadoEm { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid ColaboradorId { get; set; } // Responsável pela equipe
        public ColaboradorDTO? Colaborador { get; set; }
    }
}
