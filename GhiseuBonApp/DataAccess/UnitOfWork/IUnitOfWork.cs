using DataAccess.Data;

namespace DataAccess.UnitOfWork
{
    public interface IUnitOfWork
    {
        IGhiseuRepository Ghiseu { get; }
    }
}