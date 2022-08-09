namespace Rasdoc.Entities.Models
{
    public class ManutencaoDeClasseDependencia
    {
        public Guid Id { get; set; }
        public Guid ManutencaoDeClasseId { get; set; }
        public ManutencaoDeClasse? ManutencaoDeClasse { get; set; }
        public Guid ClasseId { get; set; }
        public Classe? Classe { get; set; }
    }
}