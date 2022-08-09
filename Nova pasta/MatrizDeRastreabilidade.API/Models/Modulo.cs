namespace MatrizDeRastreabilidade.API.Models
{
    public class Modulo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Codigo { get; set; }
        public int ProjetoId { get; set; }
        public Projeto Projeto { get; set; }
    }
}
