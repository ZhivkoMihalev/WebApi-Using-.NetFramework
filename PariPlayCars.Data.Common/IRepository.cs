namespace PariPlayCars.Data.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IRepository<TEntity> : IDisposable
       where TEntity : class
    {
        Task<IEnumerable<TEntity>> All();

        Task<TEntity> GetByIdAsync(string id);

        Task<TEntity> Add(TEntity entity);

        Task<TEntity> Remove(TEntity entity);

        Task<int> SaveChangesAsync();
    }
}
