using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Rasdoc.DTO.Models
{
    public record ProjetoColaboradorDTO
    {
        [Key] 
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid ProjetoId { get; set; }
        [JsonIgnore]
        public ProjetoDTO? Projeto { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid ColaboradorId { get; set; }
        [JsonIgnore]
        public ColaboradorDTO? Colaborador { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTimeOffset IniciadoEm { get; set; }
        public DateTimeOffset? FinalizadoEm { get; set; }
    }
}
