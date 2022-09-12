using System.ComponentModel.DataAnnotations;

namespace Rasdoc.DTO.Models
{
    public record ClasseDTO
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string? Codigo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid ModuloId { get; set; }
        public ModuloDTO? Modulo { get; set; }

        public ICollection<ManutencaoDeClasseDTO>? ManutencaoDeClasses { get; set; }
    }
}
