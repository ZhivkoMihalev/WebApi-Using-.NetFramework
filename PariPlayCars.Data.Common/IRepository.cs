namespace PariPlayCars.Data.Common
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IRepository<TEntity> : IDisposable
       where TEntity : class
    {
        IQueryable<TEntity> All();

        Task<TEntity> GetByIdAsync(string id);

        void Add(TEntity entity);

        void Delete(TEntity entity);

        Task<int> SaveChangesAsync();
    }
}
