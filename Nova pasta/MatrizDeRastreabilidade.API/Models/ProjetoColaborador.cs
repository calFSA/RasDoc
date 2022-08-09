using System;

namespace MatrizDeRastreabilidade.API.Models
{
    public class ProjetoColaborador
    {
        public int Id { get; set; }
        public int ProjetoId { get; set; }
        public Projeto Projeto { get; set; }
        public string ColaboradorId { get; set; }
        public Colaborador Colaborador { get; set; }
        public DateTime IniciadoEm { get; set; }
        public DateTime? FinalizadoEm { get; set; }
    }
}
