namespace Rasdoc.DTO.Models
{
    public class ProjetoDTO
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? Apelido { get; set; }
        public bool Ativo { get; set; }
        public DateTime IniciadoEm { get; set; }
        public DateTime? FinalizadoEm { get; set; }
        public Guid EquipeId { get; set; }
        public EquipeDTO? Equipe { get; set; }
        public ICollection<ProjetoColaboradorDTO>? Colaboradores { get; set; }
    }
}
