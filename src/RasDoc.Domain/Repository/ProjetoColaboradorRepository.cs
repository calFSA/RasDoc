using Rasdoc.Entities.Models;
using RasDoc.Domain.Context;
using RasDoc.Domain.Interfaces;

namespace RasDoc.Domain.Repository
{
    public class ProjetoColaboradorRepository : BaseRepository<ProjetoColaborador>, IProjetoColaboradorRepository
    {
        public ProjetoColaboradorRepository(ApplicationDbContext context, INotifier notifier) : base(context, notifier)
        {
        }
    }
}
 