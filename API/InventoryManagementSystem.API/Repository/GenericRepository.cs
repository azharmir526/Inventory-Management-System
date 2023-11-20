using InventoryManagementSystem.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;

namespace InventoryManagementSystem.API.Repository
{
    public class GenericRepository<TModel> : IRepository<TModel> where TModel : class, IEntity
    {
        protected readonly AppDBContext _dbContext;
        public GenericRepository(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<long> AddAsync(TModel entity)
        {
            await _dbContext.Set<TModel>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var entity = _dbContext.Set<TModel>().Find(id);
            if (entity == null)
            {
                return false;
            }
            _dbContext.Set<TModel>().Remove(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<TModel>> FindAllAsync()
        {
            var query = _dbContext.Set<TModel>();
            return await query.ToListAsync();
        }

        public async Task<TModel> FindByIdAsync(long id)
        {
            return await _dbContext.Set<TModel>().FirstOrDefaultAsync(x => x.Id == id) ?? throw new NotFoundException($"No record with ID --> {id} found");
        }

        public async Task<bool> UpdateAsync(TModel entity)
        {
            _dbContext.Set<TModel>().Update(entity);
            int rowsAffected = await _dbContext.SaveChangesAsync();
            return rowsAffected > 0;
        }
    }
}
