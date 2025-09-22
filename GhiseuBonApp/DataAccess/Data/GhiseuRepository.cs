using DataAccess.Data;
using DataAccess.DbAccess;
using DataAccess.Models;

public class GhiseuRepository : GenericRepository<GhiseuModel, int>, IGhiseuRepository
{
    public GhiseuRepository(ISqlAccess db)
        : base(db, "dbo", "Ghiseu") // Pass schema and entity name to the base class
    {
    }

    public override Task InsertAsync(GhiseuModel ghiseu) =>
            _db.SaveData($"{_schema}.sp{_entityName}_Insert", new
            {
                ghiseu.Cod,
                ghiseu.Denumire,
                ghiseu.Descriere,
                ghiseu.Icon,
                ghiseu.Activ
            });

    public Task MarkAsActive(int id) =>
        _db.SaveData($"{_schema}.sp{_entityName}_MarkAsActive", new { Id = id });

    public Task MarkAsInactive(int id) =>
        _db.SaveData($"{_schema}.sp{_entityName}_MarkAsInactive", new { Id = id });
}
