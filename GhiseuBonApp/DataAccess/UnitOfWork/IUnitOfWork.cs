using DataAccess.Data;

namespace DataAccess.UnitOfWork
{
    public interface IUnitOfWork
    {
        IGhiseuRepository Ghiseu { get; }
        IBonRepository Bon { get; }
        IUserRepository User { get; }
    }
}