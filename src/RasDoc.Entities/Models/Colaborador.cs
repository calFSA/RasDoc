using Microsoft.AspNetCore.Identity;

namespace Rasdoc.Entities.Models
{
    public class Colaborador
    {
        public Guid Id { get; set; } 
        public string? Nome { get; set; }
        public virtual ICollection<ProjetoColaborador>? ProjetoColaborador { get; set; }
    }
}
