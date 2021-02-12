using MatrizDeRastreabilidade.API.Helpers;
using MatrizDeRastreabilidade.API.Models;
using MatrizDeRastreabilidade.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatrizDeRastreabilidade.API.Repositories
{
    public class ColaboradorRepository : ControllerBaseHelper, IColaboradorRepository
    {
        private readonly UserManager<Colaborador> _userManager;
        public ColaboradorRepository(IServiceProvider serviceProvider, UserManager<Colaborador> userManager) : base(serviceProvider)
        {
            _userManager = userManager;
        }

        public void Cadastrar(Colaborador colaborador, string senha)
        {
        }

        public Colaborador Retornar(string email, string senha)
        {
        }

        public Colaborador Retornar(string id)
        {
        }
    }
}
