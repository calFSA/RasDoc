namespace Rasdoc.DTO.Models
{
    public class ProjetoColaboradorDTO
    {
        public Guid Id { get; set; }
        public Guid ProjetoId { get; set; }
        public ProjetoDTO? Projeto { get; set; }
        public string? ColaboradorId { get; set; }
        public ColaboradorDTO? Colaborador { get; set; }
        public DateTime IniciadoEm { get; set; }
        public DateTime? FinalizadoEm { get; set; }
    }
}
