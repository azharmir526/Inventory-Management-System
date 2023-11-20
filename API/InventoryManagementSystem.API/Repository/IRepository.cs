namespace InventoryManagementSystem.API.Repository
{
    public interface IRepository<TModel>
    {
        Task<TModel> FindByIdAsync(long id);
        Task<List<TModel>> FindAllAsync();
        Task<long> AddAsync(TModel entity);
        Task<bool> UpdateAsync(TModel entity);
        Task<bool> DeleteAsync(long id);
    }
}
