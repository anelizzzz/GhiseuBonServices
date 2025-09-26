using DataAccess.DbAccess;

namespace DataAccess.Data;

public class GenericRepository<TEntity, TKey>
    where TEntity : class
{
    protected readonly ISqlAccess _db;
    protected readonly string _schema;
    protected readonly string _entityName;

    public GenericRepository(ISqlAccess db, string schema, string entityName)
    {
        _db = db;
        _schema = schema;
        _entityName = entityName;
    }

    public Task<IEnumerable<TEntity>> GetAllAsync() =>
            _db.LoadData<TEntity, dynamic>($"{_schema}.sp{_entityName}_GetAll", new { });

    public async Task<TEntity?> GetByIdAsync(TKey id)
    {
        var results = await _db.LoadData<TEntity, dynamic>(
            $"{_schema}.sp{_entityName}_Get",
            new { Id = id });
        return results.FirstOrDefault();
    }

    public virtual Task InsertAsync(TEntity entity) =>
        _db.SaveData($"{_schema}.sp{_entityName}_Insert", entity);

    public virtual Task UpdateAsync(TEntity entity) =>
        _db.SaveData($"{_schema}.sp{_entityName}_Update", entity);

    public Task DeleteAsync(TKey id) =>
        _db.SaveData($"{_schema}.sp{_entityName}_Delete", new { Id = id });

}
