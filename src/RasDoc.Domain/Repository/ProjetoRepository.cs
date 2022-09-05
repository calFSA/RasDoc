using Microsoft.EntityFrameworkCore;
using Rasdoc.Entities.Models;
using RasDoc.Domain.Context;
using RasDoc.Domain.Interfaces;
using System.Linq.Expressions;

namespace RasDoc.Domain.Repository
{
    public class ProjetoRepository : IProjetoRepository
    {
        private readonly IBaseRepository<Projeto> _baseRepository;
        private readonly ApplicationDbContext _context;

        public ProjetoRepository(IBaseRepository<Projeto> baseRepository, ApplicationDbContext context)
        {
            _baseRepository = baseRepository;
            _context = context;
        }

        public async Task<bool> AddAsync(Projeto projeto)
        {
            return await _baseRepository.AddAsync(projeto);
        }
       
        public async Task<bool> UpdateAsync(Projeto projeto)
        {
            return await _baseRepository.UpdateAsync(projeto);
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            return await _baseRepository.RemoveAsync(id);
        }

        public async Task<IEnumerable<Projeto>> CustomSearchAsync(Expression<Func<Projeto, bool>> filter = null!)
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

        void IDisposable.Dispose()
        {
            _baseRepository.Dispose();
        }
    }
}
