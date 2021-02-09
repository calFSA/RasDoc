using System;

namespace MatrizDeRastreabilidade.API.Model
{
    public class ProjetoColaborador
    {
        public int Id { get; set; }
        public int ProjetoId { get; set; }
        public virtual Projeto Projeto { get; set; }
        public int ColaboradorId { get; set; }
        public virtual Colaborador Colaborador { get; set; }
        public DateTime IniciadoEm { get; set; }
        public DateTime? FinalizadoEm { get; set; }
    }
}
