using Microsoft.EntityFrameworkCore;
using Rasdoc.Entities.Models;
using RasDoc.Domain.Context;
using RasDoc.Domain.Interfaces;
using System.Linq.Expressions;

namespace RasDoc.Domain.Repository
{
    public class ProjetoRepository : BaseRepository<Projeto>, IProjetoRepository 
    {
        private readonly ApplicationDbContext _context;

        public ProjetoRepository(ApplicationDbContext context, INotifier notifier) : base(context, notifier)
        {
            _context = context;
        }

        public new async Task<IEnumerable<Projeto>> CustomSearchAsync(Expression<Func<Projeto, bool>> filter = null!)
        {
            return filter == null   
                ? await _context.Projeto!.AsNoTrackingWithIdentityResolution()
                                        .Include(pc => pc.ProjetosColaborador)!
                                        .Include(e => e.Equipe)
                                            .ThenInclude(c => c!.Colaborador)
                                        .ToListAsync()
                : await _context.Projeto!.AsNoTrackingWithIdentityResolution()
                                        .Include(p => p.ProjetosColaborador)!
                                        .Include(e => e.Equipe)
                                            .ThenInclude(c => c!.Colaborador)
                                        .Where(filter).ToListAsync();
        }
    }
}
