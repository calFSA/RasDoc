using Microsoft.EntityFrameworkCore;
using Rasdoc.Entities.Models;
using RasDoc.Domain.Context;
using RasDoc.Domain.Interfaces;
using System.Linq.Expressions;

namespace RasDoc.Domain.Repository
{
    public class ColaboradorRepository : IColaboradorRepository
    {
        private readonly IBaseRepository<Colaborador> _baseRepository;
        private readonly ApplicationDbContext _context;

        public ColaboradorRepository(IBaseRepository<Colaborador> baseRepository, ApplicationDbContext context)
        {
            _baseRepository = baseRepository;
            _context = context;
        }

        public async Task<bool> AddAsync(Colaborador colaborador)
        {
            return await _baseRepository.AddAsync(colaborador);
        }
       
        public async Task<bool> UpdateAsync(Colaborador colaborador)
        {
            return await _baseRepository.UpdateAsync(colaborador);
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            return await _baseRepository.RemoveAsync(id);
        }

        public async Task<IEnumerable<Colaborador>> CustomSearchAsync(Expression<Func<Colaborador, bool>> filter = null!)
        {
            return filter == null
                ? await _context.Colaborador!.AsNoTrackingWithIdentityResolution()
                                        .Include(p => p.ProjetosColaborador).ToListAsync()
                : await _context.Colaborador!.AsNoTrackingWithIdentityResolution()
                                        .Include(p => p.ProjetosColaborador)
                                        .Where(filter).ToListAsync();
        }

        void IDisposable.Dispose()
        {
            _baseRepository.Dispose();
        }
    }
}
