using System.ComponentModel.DataAnnotations;

namespace Rasdoc.DTO.Models
{
    public class ProjetoColaboradorDTO
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid ProjetoId { get; set; }
        public ProjetoDTO? Projeto { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string? ColaboradorId { get; set; }
        public ColaboradorDTO? Colaborador { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime IniciadoEm { get; set; }
        public DateTime? FinalizadoEm { get; set; }
    }
}
