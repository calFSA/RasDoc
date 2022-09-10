using RasDoc.Entities.Models;

namespace Rasdoc.Entities.Models
{
    public class ProjetoColaborador : EntityBase 
    {
        public Guid ProjetoId { get; set; }
        public Projeto? Projeto { get; set; }
        public Guid ColaboradorId { get; set; }
        public Colaborador? Colaborador { get; set; }
        public DateTimeOffset IniciadoEm { get; set; }
        public DateTimeOffset? FinalizadoEm { get; set; }
    }
}
