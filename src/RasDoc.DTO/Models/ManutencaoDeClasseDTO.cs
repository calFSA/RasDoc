using System.ComponentModel.DataAnnotations;

namespace Rasdoc.DTO.Models
{
    public record ManutencaoDeClasseDTO
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string? Codigo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string? Localizacao { get; set; }

        public ICollection<ManutencaoDeClasseDependenciaDTO>? ManutencaoDeClasseDependencias { get; set; }
    }
}
