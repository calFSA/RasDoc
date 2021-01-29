namespace MatrizDeRastreabilidade.API.Model
{
    public class Classe
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Codigo { get; set; }
        public int ModuloId { get; set; }
        public Modulo Modulo { get; set; }
    }
}
