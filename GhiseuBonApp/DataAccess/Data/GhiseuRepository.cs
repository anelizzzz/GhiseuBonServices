using DataAccess.DbAccess;
using DataAccess.Models;

namespace DataAccess.Data;

public class GhiseuRepository : IGhiseuRepository
{
    private readonly ISqlAccess _db;

    public GhiseuRepository(ISqlAccess db)
    {
        _db = db;
    }

    public Task<IEnumerable<GhiseuModel>> GetAllItems() =>
       _db.LoadData<GhiseuModel, dynamic>("dbo.spGhiseu_GetAll", new { });
    public async Task<GhiseuModel?> GetGhiseu(int id)
    {
        var results = await _db.LoadData<GhiseuModel, dynamic>(
            "dbo.spGhiseu_Get",
            new { Id = id });
        return results.FirstOrDefault();
    }

    public Task InsertGhiseu(GhiseuModel ghiseu) =>
        _db.SaveData("dbo.spGhiseu_Insert", new { ghiseu.Cod, ghiseu.Denumire, ghiseu.Descriere, ghiseu.Icon, ghiseu.Activ });

    public Task UpdateGhiseu(GhiseuModel ghiseu) =>
        _db.SaveData("dbo.spGhiseu_Update", ghiseu);

    public Task DeleteGhiseu(int id) =>
        _db.SaveData("dbo.spGhiseu_Delete", new { Id = id });
    public Task MarkAsActive(int id) =>
    _db.SaveData("dbo.spGhiseu_MarkAsActive", new { Id = id });

    public Task MarkAsInactive(int id) =>
        _db.SaveData("dbo.spGhiseu_MarkAsInactive", new { Id = id });

}
