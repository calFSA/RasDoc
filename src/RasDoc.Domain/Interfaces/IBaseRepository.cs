using RasDoc.Entities.Models;
using System.Linq.Expressions;

namespace RasDoc.Domain.Interfaces
{                   
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : EntityBase
    {
        Task<bool> AddAsync(TEntity entity);
        Task<bool> UpdateAsync(TEntity entity);
        Task<bool> RemoveAsync(Guid id);
        Task<IEnumerable<TEntity>> CustomSearchAsync(Expression<Func<TEntity, bool>> filter = null!);
    }
}
