
namespace DataAccess.Data
{
    public interface IGenericRepository<TEntity, TKey> where TEntity : class
    {
        Task DeleteAsync(TKey id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity?> GetByIdAsync(TKey id);
        Task InsertAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
    }
}