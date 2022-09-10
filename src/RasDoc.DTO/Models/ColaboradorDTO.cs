using System.ComponentModel.DataAnnotations;

namespace Rasdoc.DTO.Models
{
    public record ColaboradorDTO
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public bool Ativo { get; set; }

        public virtual ICollection<ProjetoColaboradorDTO>? ProjetosColaborador { get; set; }
    }
}
