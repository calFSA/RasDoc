using Rasdoc.Entities.Models;
using RasDoc.Domain.Interfaces;
using System.Linq.Expressions;

namespace RasDoc.Domain.Repository
{
    public class ColaboradorRepository : IColaboradorRepository
    {
        private readonly IBaseRepository<Colaborador> _baseRepository;

        public ColaboradorRepository(IBaseRepository<Colaborador> baseRepository)
        {
            _baseRepository = baseRepository;
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
            return await _baseRepository.CustomSearchAsync(filter);
        }

        void IDisposable.Dispose()
        {
            _baseRepository.Dispose();
        }
    }
}
