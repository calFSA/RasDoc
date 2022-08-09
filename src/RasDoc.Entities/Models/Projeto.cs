namespace Rasdoc.Entities.Models
{
    public class Projeto
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? Apelido { get; set; }
        public bool Ativo { get; set; }
        public DateTime IniciadoEm { get; set; }
        public DateTime? FinalizadoEm { get; set; }
        public Guid EquipeId { get; set; }
        public Equipe? Equipe { get; set; }
        public ICollection<ProjetoColaborador>? Colaboradores { get; set; }
    }
}
