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
    public Task<IEnumerable<GhiseuModel>> GetAllAsync() => GetAllItems();

    public Task<GhiseuModel?> GetByIdAsync(int id) => GetGhiseu(id);

    public Task InsertAsync(GhiseuModel ghiseu) => InsertGhiseu(ghiseu);

    public Task UpdateAsync(GhiseuModel ghiseu) => UpdateGhiseu(ghiseu);

    public Task DeleteAsync(int id) => DeleteGhiseu(id);

    public Task<IEnumerable<GhiseuModel>> GetAllItems() =>
        _db.LoadData<GhiseuModel, dynamic>("bon.spGhiseu_GetAll", new { });

    public async Task<GhiseuModel?> GetGhiseu(int id)
    {
        var results = await _db.LoadData<GhiseuModel, dynamic>(
            "bon.spGhiseu_Get",
            new { Id = id });
        return results.FirstOrDefault();
    }

    public Task InsertGhiseu(GhiseuModel ghiseu) =>
        _db.SaveData("bon.spGhiseu_Insert", new { ghiseu.Cod, ghiseu.Denumire, ghiseu.Descriere, ghiseu.Icon, ghiseu.Activ });

    public Task UpdateGhiseu(GhiseuModel ghiseu) =>
        _db.SaveData("bon.spGhiseu_Update", ghiseu);

    public Task DeleteGhiseu(int id) =>
        _db.SaveData("bon.spGhiseu_Delete", new { Id = id });

    public Task MarkAsActive(int id) =>
        _db.SaveData("bon.spGhiseu_MarkAsActive", new { Id = id });

    public Task MarkAsInactive(int id) =>
        _db.SaveData("bon.spGhiseu_MarkAsInactive", new { Id = id });
}
