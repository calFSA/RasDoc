namespace MatrizDeRastreabilidade.API.Models
{
    public class ManutencaoDeClasseDependencia
    {
        public int Id { get; set; }
        public int ManutencaoDeClasseId { get; set; }
        public ManutencaoDeClasse ManutencaoDeClasse { get; set; }
        public int ClasseId { get; set; }
        public Classe Classe { get; set; }
    }
}
