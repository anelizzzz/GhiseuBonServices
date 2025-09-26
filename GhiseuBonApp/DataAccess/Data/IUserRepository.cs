using DataAccess.Models;

namespace DataAccess.Data
{
    public interface IUserRepository : IGenericRepository<UserModel, int>
    {
        Task InsertAsync(UserModel user);
        Task UpdateAsync(UserModel user);
        Task<UserModel?> GetByUsernameAsync(string username);
    }
}