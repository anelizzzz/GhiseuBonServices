using DataAccess.DbAccess;
using DataAccess.Models;

namespace DataAccess.Data;

public class BonRepository
{
    private readonly ISqlAccess _db;
    public BonRepository(ISqlAccess db)
    {
        _db = db;
    }

    public Task<IEnumerable<BonModel>> GetAllItems() =>
        _db.LoadData<BonModel, dynamic>("bon.spBon_GetAll", new { });
}
