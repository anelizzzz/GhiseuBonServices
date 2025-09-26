using DataAccess.DbAccess;
using DataAccess.Models;

namespace DataAccess.Data;

public class UserRepository : GenericRepository<UserModel, int>, IUserRepository
{
    public UserRepository(ISqlAccess db) : base(db, "dbo", "User")
    {

    }
    public override async Task InsertAsync(UserModel user)
    {
        user.PasswordHash = PasswordHasher.HashPassword(user.PasswordHash);
        await _db.SaveData($"{_schema}.sp{_entityName}_Insert", new
        {
            user.FirstName,
            user.LastName,
            user.UserName,
            user.Email,
            user.PasswordHash,
            user.RoleUser,
            user.CreatedAt,
        });
    }
    public override async Task UpdateAsync(UserModel user)
    {
        user.PasswordHash = PasswordHasher.HashPassword(user.PasswordHash);
        await _db.SaveData($"{_schema}.sp{_entityName}_Insert", new
        {
            user.FirstName,
            user.LastName,
            user.UserName,
            user.Email,
            user.PasswordHash,
            user.RoleUser,
            user.CreatedAt,
        });
    }

}
