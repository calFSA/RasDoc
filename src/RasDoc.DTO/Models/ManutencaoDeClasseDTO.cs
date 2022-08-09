namespace Rasdoc.DTO.Models
{
    public class ManutencaoDeClasseDTO
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? Codigo { get; set; }
        public string? Localizacao { get; set; }
        public ICollection<ManutencaoDeClasseDependenciaDTO>? ManutencaoDeClasseDependencias { get; set; }
    }
}
