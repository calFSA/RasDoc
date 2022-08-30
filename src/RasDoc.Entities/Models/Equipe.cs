using RasDoc.Entities.Models;

namespace Rasdoc.Entities.Models
{
    public class Equipe : EntityBase
    {
        public string? Nome { get; set; }
        public bool Ativo { get; set; } = true;
        public DateTime IniciadoEm { get; set; }
        public DateTime? FinalizadoEm { get; set; }
        public Guid ColaboradorId { get; set; } // Responsável pela equipe
        public Colaborador? Colaborador { get; set; }
    }
}
