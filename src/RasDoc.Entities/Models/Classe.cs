using RasDoc.Entities.Models;

namespace Rasdoc.Entities.Models
{
    public class Classe : EntityBase
    {
        public string? Nome { get; set; }
        public string? Codigo { get; set; }
        public Guid ModuloId { get; set; }
        public Modulo? Modulo { get; set; }
        public ICollection<ManutencaoDeClasse>? ManutencaoDeClasses { get; set; }
    }
}
