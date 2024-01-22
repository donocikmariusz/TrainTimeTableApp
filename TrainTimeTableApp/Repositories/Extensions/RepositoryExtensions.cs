using LokApp.Entities;
using LokApp.Repositories;

namespace TrainTimeTableApp.Repositories.Extensions
{
    public static class RepositoryExtensions
    {
        public static void AddBatch<T>(this IRepository<T> repository, T[] items)
             where T : class, IEntity
        {
            foreach (var number in items)
            {
                repository.Add(number);
            }
            repository.Save();
        }
    }
}
