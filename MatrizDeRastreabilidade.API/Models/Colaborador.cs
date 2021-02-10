using System.Collections.Generic;

namespace MatrizDeRastreabilidade.API.Models
{
    public class Colaborador
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<ProjetoColaborador> ProjetosColaboradores { get; set; }
    }
}
