using Microsoft.EntityFrameworkCore;
using Rasdoc.Entities.Models;
using RasDoc.Domain.Context;
using RasDoc.Domain.Interfaces;
using System.Linq.Expressions;

namespace RasDoc.Domain.Repository
{
    public class ColaboradorRepository : BaseRepository<Colaborador>, IColaboradorRepository
    {
        private readonly ApplicationDbContext _context;

        public ColaboradorRepository(ApplicationDbContext context, INotifier notifier) : base(context, notifier)
        {
            _context = context;
        }

        public new async Task<IEnumerable<Colaborador>> CustomSearchAsync(Expression<Func<Colaborador, bool>> filter = null!)
        {
            return filter == null
                ? await _context.Colaborador!.AsNoTrackingWithIdentityResolution()
                                        .Include(p => p.ProjetosColaborador).ToListAsync()
                : await _context.Colaborador!.AsNoTrackingWithIdentityResolution()
                                        .Include(p => p.ProjetosColaborador)
                                        .Where(filter).ToListAsync();
        }
    }
}
