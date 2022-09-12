using RasDoc.Entities.Models;

namespace Rasdoc.Entities.Models
{
    public class ManutencaoDeClasse : EntityBase
    {
        public string? Nome { get; set; }
        public string? Codigo { get; set; }
        public string? Localizacao { get; set; }
        public Guid ClasseId { get; set; }
        public Classe? Classe { get; set; }
        public ICollection<ManutencaoDeClasseDependencia>? ManutencaoDeClasseDependencias { get; set; }
    }
}
