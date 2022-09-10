using Microsoft.EntityFrameworkCore;
using Rasdoc.Entities.Models;
using RasDoc.Domain.Context;
using RasDoc.Domain.Interfaces;
using System.Linq.Expressions;

namespace RasDoc.Domain.Repository
{
    public class ProjetoColaboradorRepository : BaseRepository<ProjetoColaborador>, IProjetoColaboradorRepository
    {
        public ProjetoColaboradorRepository(ApplicationDbContext context) : base(context, null!)
        {
        }
    }
}
 