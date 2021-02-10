using System;

namespace MatrizDeRastreabilidade.API.Models
{
    public class Equipe
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; } = true;
        public DateTime IniciadoEm { get; set; }
        public DateTime? FinalizadoEm { get; set; }
        public int ColaboradorId { get; set; } // Responsável pela equipe
        public Colaborador Colaborador { get; set; }
    }
}
