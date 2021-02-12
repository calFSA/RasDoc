using MatrizDeRastreabilidade.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatrizDeRastreabilidade.API.Repositories.Interfaces
{
    public interface IColaboradorRepository
    {
        void Cadastrar(Colaborador colaborador, string senha);
        Colaborador Retornar(string email, string senha);
        Colaborador Retornar(string id);
    }
}
