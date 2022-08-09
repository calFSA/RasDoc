namespace Rasdoc.DTO.Models
{
    public class ModuloDTO
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? Codigo { get; set; }
        public Guid ProjetoId { get; set; }
        public ProjetoDTO? Projeto { get; set; }
    }
}
