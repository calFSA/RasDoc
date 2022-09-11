using Microsoft.EntityFrameworkCore;
using Rasdoc.Entities.Models;
using RasDoc.Domain.Context;
using RasDoc.Domain.Interfaces;
using System.Linq.Expressions;

namespace RasDoc.Domain.Repository
{
    public class ClasseRepository : BaseRepository<Classe>, IClasseRepository
    {
        private readonly ApplicationDbContext _context;

        public ClasseRepository(ApplicationDbContext context, INotifier notifier) : base(context, notifier)
        {
            _context = context;
        }

        public new async Task<IEnumerable<Classe>> CustomSearchAsync(Expression<Func<Classe, bool>> filter = null!)
        {
            return filter == null
                ? await _context.Classe!.AsNoTrackingWithIdentityResolution()
                                        .Include(m => m.Modulo)!
                                            .ThenInclude(p => p!.Projeto)
                                            .ThenInclude(e => e!.Equipe)
                                            .ThenInclude(c => c!.Colaborador)
                                        .ToListAsync()
                : await _context.Classe!.AsNoTrackingWithIdentityResolution()
                                        .Include(m => m.Modulo)!
                                            .ThenInclude(p => p!.Projeto)
                                            .ThenInclude(e => e!.Equipe)
                                            .ThenInclude(c => c!.Colaborador)
                                        .Where(filter)
                                        .ToListAsync();
        }
    }
}
