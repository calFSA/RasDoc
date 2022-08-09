using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace MatrizDeRastreabilidade.API.Models
{
    public class Colaborador : IdentityUser
    {
        public string Nome { get; set; }
        public virtual ICollection<ProjetoColaborador> ProjetoColaborador { get; set; }
    }
}
