using Microsoft.EntityFrameworkCore;
using Rasdoc.Entities.Models;
using RasDoc.Domain.Context;
using RasDoc.Domain.Interfaces;
using System.Linq.Expressions;

namespace RasDoc.Domain.Repository
{
    public class ManutencaoDeClasseRepository : BaseRepository<ManutencaoDeClasse>, IManutencaoDeClasseRepository
    {
        private readonly ApplicationDbContext _context;

        public ManutencaoDeClasseRepository(ApplicationDbContext context, INotifier notifier) : base(context, notifier)
        {
            _context = context;
        }

        public new async Task<IEnumerable<ManutencaoDeClasse>> CustomSearchAsync(Expression<Func<ManutencaoDeClasse, bool>> filter = null!)
        {
            return filter == null
                ? await _context.ManutencaoDeClasse!.AsNoTrackingWithIdentityResolution()
                                                    .Include(p => p.ManutencaoDeClasseDependencias)!
                                                    .ToListAsync()
                : await _context.ManutencaoDeClasse!.AsNoTrackingWithIdentityResolution()
                                                    .Include(p => p.ManutencaoDeClasseDependencias)!
                                                    .Where(filter)
                                                    .ToListAsync();
        }
    }
}
