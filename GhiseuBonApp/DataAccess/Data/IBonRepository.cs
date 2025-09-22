using DataAccess.Models;

namespace DataAccess.Data
{
    public interface IBonRepository : IGenericRepository<BonModel, int>
    {
        Task DeleteBon(int id);
        Task<IEnumerable<BonModel>> GetAllItems();
        Task<BonModel?> GetBon(int id);
        Task InsertBon(BonModel bon);
        Task MarkAsClosed(int id);
        Task MarkAsInProgress(int id);
        Task MarkAsReceived(int id);
        //Task UpdateBon(BonModel bon);
    }
}