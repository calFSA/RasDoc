namespace Rasdoc.Entities.Models
{
    public class ManutencaoDeClasse
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? Codigo { get; set; }
        public string? Localizacao { get; set; }
        public ICollection<ManutencaoDeClasseDependencia>? ManutencaoDeClasseDependencias { get; set; }
    }
}
