namespace Rasdoc.Entities.Models
{
    public class Classe
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? Codigo { get; set; }
        public Guid ModuloId { get; set; }
        public Modulo? Modulo { get; set; }
    }
}
