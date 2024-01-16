
using LokApp.Entities;
using System.Security.Principal;


namespace LokApp.Repositories
{
    public interface IRepository<T> : IReadRepository<T>, IWriteRepository<T>
        where T : class, IEntity
    {

    }
}
