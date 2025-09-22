using DataAccess.Data;
using DataAccess.DbAccess;
using DataAccess.Models;


public class BonRepository : GenericRepository<BonModel, int>, IBonRepository
{
    public BonRepository(ISqlAccess db)
        : base(db, "dbo", "Bon")
    {
    }
    public override Task InsertAsync(BonModel bon) =>
            _db.SaveData($"{_schema}.sp{_entityName}_Insert", new
            {
                bon.IdGhiseu,
                bon.Stare,
                bon.CreatedAt,
                bon.ModifiedAt
            });

    public Task MarkAsInProgress(int id) =>
        _db.SaveData("dbo.spBon_MarkAsInProgress", new { Id = id });

    public Task MarkAsReceived(int id) =>
        _db.SaveData("dbo.spBon_MarkAsReceived", new { Id = id });

    public Task MarkAsClosed(int id) =>
        _db.SaveData("dbo.spBon_MarkAsClosed", new { Id = id });
}
