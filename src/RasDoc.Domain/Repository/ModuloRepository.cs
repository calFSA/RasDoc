using Microsoft.EntityFrameworkCore;
using Rasdoc.Entities.Models;
using RasDoc.Domain.Context;
using RasDoc.Domain.Interfaces;
using System.Linq.Expressions;

namespace RasDoc.Domain.Repository
{
    public class ModuloRepository : BaseRepository<Modulo>, IModuloRepository
    {
        private readonly ApplicationDbContext _context;

        public ModuloRepository(ApplicationDbContext context, INotifier notifier) : base(context, notifier)
        {
            _context = context;
        }

        public new async Task<IEnumerable<Modulo>> CustomSearchAsync(Expression<Func<Modulo, bool>> filter = null!)
        {
            return filter == null
                ? await _context.Modulo!.AsNoTrackingWithIdentityResolution()
                                        .Include(p => p.Projeto)!
                                            .ThenInclude(e => e!.Equipe)
                                            .ThenInclude(c => c!.Colaborador)
                                        .ToListAsync()
                : await _context.Modulo!.AsNoTrackingWithIdentityResolution()
                                        .Include(p => p.Projeto)!
                                            .ThenInclude(e => e!.Equipe)
                                            .ThenInclude(c => c!.Colaborador)
                                        .Where(filter)
                                        .ToListAsync();
        }
    }
}
