using LokApp.Entities;

// KONTRAWARIANCJA

namespace LokApp.Repositories
{
    public interface IWriteRepository<in T> where T : class, IEntity
    {
        void Add(T entity);
        void Remove(T entity);
        void Save();

    }
}
