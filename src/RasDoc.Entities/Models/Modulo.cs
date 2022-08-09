namespace Rasdoc.Entities.Models
{
    public class Modulo
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? Codigo { get; set; }
        public Guid ProjetoId { get; set; }
        public Projeto? Projeto { get; set; }
    }
}
