using DataAccess.Data;
using DataAccess.DbAccess;

namespace DataAccess.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    public IGhiseuRepository Ghiseu { get; }
    public UnitOfWork(ISqlAccess db)
    {
        Ghiseu = new GhiseuRepository(db);
    }
}
