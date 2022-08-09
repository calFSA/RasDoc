namespace Rasdoc.DTO.Models
{
    public class ManutencaoDeClasseDependenciaDTO
    {
        public Guid Id { get; set; }
        public Guid ManutencaoDeClasseId { get; set; }
        public ManutencaoDeClasseDTO? ManutencaoDeClasse { get; set; }
        public Guid ClasseId { get; set; }
        public ClasseDTO? Classe { get; set; }
    }
}