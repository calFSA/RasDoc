namespace Rasdoc.DTO.Models
{
    public class ColaboradorDTO
    {
        public string? Nome { get; set; }
        public virtual ICollection<ProjetoColaboradorDTO>? ProjetoColaborador { get; set; }
    }
}
