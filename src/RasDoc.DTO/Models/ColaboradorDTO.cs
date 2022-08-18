namespace Rasdoc.DTO.Models
{
    public class ColaboradorDTO
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public bool Ativo { get; set; }
        public virtual ICollection<ProjetoColaboradorDTO>? ProjetosColaborador { get; set; }
    }
}
