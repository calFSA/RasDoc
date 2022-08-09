namespace Rasdoc.DTO.Models
{
    public class ClasseDTO
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? Codigo { get; set; }
        public Guid ModuloId { get; set; }
        public ModuloDTO? Modulo { get; set; }
    }
}
