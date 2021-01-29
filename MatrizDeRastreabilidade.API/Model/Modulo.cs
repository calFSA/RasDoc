namespace MatrizDeRastreabilidade.API.Model
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
