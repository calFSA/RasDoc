using System.ComponentModel.DataAnnotations;

namespace Rasdoc.DTO.Models
{
    public record ManutencaoDeClasseDependenciaDTO
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid ManutencaoDeClasseId { get; set; }
        public ManutencaoDeClasseDTO? ManutencaoDeClasse { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid ClasseId { get; set; }
        public ClasseDTO? Classe { get; set; }
    }
}