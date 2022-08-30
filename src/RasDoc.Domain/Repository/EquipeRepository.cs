using Microsoft.EntityFrameworkCore;
using Rasdoc.Entities.Models;
using RasDoc.Domain.Context;
using RasDoc.Domain.Interfaces;
using System.Linq.Expressions;

namespace RasDoc.Domain.Repository
{
    public class EquipeRepository : IEquipeRepository
    {
        private readonly IBaseRepository<Equipe> _baseRepository;
        private readonly ApplicationDbContext _context;

        public EquipeRepository(IBaseRepository<Equipe> baseRepository, ApplicationDbContext context)
        {
            _baseRepository = baseRepository;
            _context = context;
        }

        public async Task<bool> AddAsync(Equipe equipe)
        {
            return await _baseRepository.AddAsync(equipe);
        }
       
        public async Task<bool> UpdateAsync(Equipe equipe)
        {
            return await _baseRepository.UpdateAsync(equipe);
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            return await _baseRepository.RemoveAsync(id);
        }

        public async Task<IEnumerable<Equipe>> CustomSearchAsync(Expression<Func<Equipe, bool>> filter = null!)
        {
            return filter == null
                ? await _context.Equipe!.AsNoTrackingWithIdentityResolution()
                                        .Include(c => c.Colaborador).ToListAsync()
                : await _context.Equipe!.AsNoTrackingWithIdentityResolution()
                                        .Include(c => c.Colaborador)
                                        .Where(filter).ToListAsync();
        }

        void IDisposable.Dispose()
        {
            _baseRepository.Dispose();
        }
    }
}
