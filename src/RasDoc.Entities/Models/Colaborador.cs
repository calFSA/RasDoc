using RasDoc.Entities.Models;

namespace Rasdoc.Entities.Models
{
    public class Colaborador : EntityBase
    {
        public string? Nome { get; set; }
        public bool Ativo { get; set; }
        public virtual ICollection<ProjetoColaborador>? ProjetosColaborador { get; set; }
    }
}
