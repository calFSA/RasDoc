namespace Rasdoc.DTO.Models
{
    public class EquipeDTO
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public bool Ativo { get; set; } = true;
        public DateTime IniciadoEm { get; set; }
        public DateTime? FinalizadoEm { get; set; }
        public Guid ColaboradorId { get; set; } // Responsável pela equipe
        public ColaboradorDTO? Colaborador { get; set; }
    }
}
