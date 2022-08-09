namespace Rasdoc.Entities.Models
{
    public class ProjetoColaborador
    {
        public Guid Id { get; set; }
        public Guid ProjetoId { get; set; }
        public Projeto? Projeto { get; set; }
        public Guid ColaboradorId { get; set; }
        public Colaborador? Colaborador { get; set; }
        public DateTime IniciadoEm { get; set; }
        public DateTime? FinalizadoEm { get; set; }
    }
}
