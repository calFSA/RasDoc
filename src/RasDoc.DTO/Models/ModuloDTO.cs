using System.ComponentModel.DataAnnotations;

namespace Rasdoc.DTO.Models
{
    public class ModuloDTO
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string? Codigo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid ProjetoId { get; set; }
        public ProjetoDTO? Projeto { get; set; }
    }
}
