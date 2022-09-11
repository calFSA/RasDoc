using Microsoft.EntityFrameworkCore;
using RasDoc.Domain.Context;
using RasDoc.Domain.Interfaces;
using RasDoc.Entities.Models;
using System.Linq.Expressions;

namespace RasDoc.Domain.Repository
{
    public class BaseRepository<TEntity> : BaseNotification, IBaseRepository<TEntity> where TEntity : EntityBase, new()
    {
        private readonly DbSet<TEntity> _DbSet;
        private readonly ApplicationDbContext _applicationDbContext;

        public BaseRepository(ApplicationDbContext applicationDbContext,
                              INotifier notifier) : base(notifier)
        {
            _DbSet = applicationDbContext.Set<TEntity>();
            _applicationDbContext = applicationDbContext;
        }

        public async Task<bool> AddAsync(TEntity entity)
        {
            try
            {
                await _DbSet.AddAsync(entity); 
                await _applicationDbContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                Notify(ex.InnerException!.Message);
                return false;
            }

            return true;
        }

        public async Task<bool> UpdateAsync(TEntity entity)
        {
            try
            {
                entity.DataAlt = DateTimeOffset.UtcNow.AddHours(-3); 
                _DbSet.Update(entity);
                await _applicationDbContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                Notify(ex.InnerException!.Message);
                return false;
            }

            return true;
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            try
            {
                _DbSet.Remove(new TEntity { Id = id });
                await _applicationDbContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                Notify(ex.InnerException!.Message);
                return false;
            }

            return true;
        }

        public async Task<IEnumerable<TEntity>> CustomSearchAsync(Expression<Func<TEntity, bool>> filter = null!)
        {
            return filter == null
                ? await _DbSet.AsNoTrackingWithIdentityResolution().ToListAsync()
                : await _DbSet.AsNoTrackingWithIdentityResolution().Where(filter).ToListAsync();
        }

        public void Dispose()
        {
            _applicationDbContext?.Dispose();
        }
    }
}
