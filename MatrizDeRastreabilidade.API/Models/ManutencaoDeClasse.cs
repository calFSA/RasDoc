using System.Collections.Generic;

namespace MatrizDeRastreabilidade.API.Models
{
    public class ManutencaoDeClasse
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Codigo { get; set; }
        public string Localizacao { get; set; }
        public virtual ICollection<ManutencaoDeClasseDependencia> ManutencaoDeClasseDependencias { get; set; }
    }
}
