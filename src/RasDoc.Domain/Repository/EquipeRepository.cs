using Microsoft.EntityFrameworkCore;
using Rasdoc.Entities.Models;
using RasDoc.Domain.Context;
using RasDoc.Domain.Interfaces;
using System.Linq.Expressions;

namespace RasDoc.Domain.Repository
{
    public class EquipeRepository : BaseRepository<Equipe>, IEquipeRepository
    {
        private readonly ApplicationDbContext _context;

        public EquipeRepository(ApplicationDbContext context) : base(context, null!)
        {
            _context = context;
        }

        public new async Task<IEnumerable<Equipe>> CustomSearchAsync(Expression<Func<Equipe, bool>> filter = null!)
        {
            return filter == null
                ? await _context.Equipe!.AsNoTrackingWithIdentityResolution()
                                        .Include(c => c.Colaborador).ToListAsync()
                : await _context.Equipe!.AsNoTrackingWithIdentityResolution()
                                        .Include(c => c.Colaborador)
                                        .Where(filter).ToListAsync();
        }
    }
}
