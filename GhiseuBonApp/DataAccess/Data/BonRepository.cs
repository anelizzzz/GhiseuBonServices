using DataAccess.DbAccess;
using DataAccess.Models;

namespace DataAccess.Data;

public class BonRepository : IBonRepository
{
    private readonly ISqlAccess _db;
    public BonRepository(ISqlAccess db)
    {
        _db = db;
    }

    public Task<IEnumerable<BonModel>> GetAllItems() =>
        _db.LoadData<BonModel, dynamic>("bon.spBon_GetAll", new { });
    public async Task<BonModel?> GetBon(int id)
    {
        var results = await _db.LoadData<BonModel, dynamic>(
            "bon.spBon_Get",
            new { Id = id });
        return results.FirstOrDefault();
    }

    public Task InsertBon(BonModel bon) =>
        _db.SaveData("bon.spBon_Insert", new { bon.IdGhiseu, bon.Stare, bon.CreatedAt, bon.ModifiedAt });

    public Task UpdateBon(BonModel bon) =>
        _db.SaveData("bon.spBon_Update", bon);

    public Task DeleteBon(int id) =>
        _db.SaveData("bon.spBon_Delete", new { Id = id });

    public Task MarkAsInProgress(int id) =>
    _db.SaveData("bon.spBon_MarkAsInProgress", new { Id = id });

    public Task MarkAsReceived(int id) =>
    _db.SaveData("bon.spBon_MarkAsReceived", new { Id = id });
    public Task MarkAsClosed(int id) =>
    _db.SaveData("bon.spBon_MarkAsClosed", new { Id = id });
}
