using RasDoc.Entities.Models;

namespace Rasdoc.Entities.Models
{
    public class Modulo : EntityBase
    {
        public string? Nome { get; set; }
        public string? Codigo { get; set; }
        public Guid ProjetoId { get; set; }
        public Projeto? Projeto { get; set; }
    }
}
