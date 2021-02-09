using System.Collections.Generic;

namespace MatrizDeRastreabilidade.API.Model
{
    public class Colaborador
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<ProjetoColaborador> ProjetosColaboradores { get; set; }
    }
}
