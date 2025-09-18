using DataAccess.Models;

namespace DataAccess.Data
{
    public interface IGhiseuRepository
    {
        Task DeleteGhiseu(int id);
        Task<IEnumerable<GhiseuModel>> GetAllItems();
        Task<GhiseuModel?> GetGhiseu(int id);
        Task InsertGhiseu(GhiseuModel ghiseu);
        Task UpdateGhiseu(GhiseuModel ghiseu);
        Task MarkAsActive(int id);
        Task MarkAsInactive(int id);
    }
}