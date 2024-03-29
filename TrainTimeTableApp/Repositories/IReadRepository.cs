﻿
using LokApp.Entities;

// KOWARIANCJA

namespace LokApp.Repositories
{
    public interface IReadRepository<out T> where T : class, IEntity
    {
        T GetById(int id);
        IEnumerable<T> GetAll();

    }
}
