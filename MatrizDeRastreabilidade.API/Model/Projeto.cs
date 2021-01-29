using System;
using System.Collections.Generic;

namespace MatrizDeRastreabilidade.API.Model
{
    public class Projeto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public bool Ativo { get; set; }
        public DateTime IniciadoEm { get; set; }
        public DateTime? FinalizadoEm { get; set; }
        public int EquipeId { get; set; }
        public Equipe Equipe { get; set; }
        public ICollection<ProjetoColaborador> Colaboradores { get; set; }
    }
}
