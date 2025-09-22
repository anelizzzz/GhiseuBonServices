using DataAccess.Models;

namespace DataAccess.Data
{
    public interface IBonRepository : IGenericRepository<BonModel, int>
    {
        Task MarkAsClosed(int id);
        Task MarkAsInProgress(int id);
        Task MarkAsReceived(int id);
    }
}