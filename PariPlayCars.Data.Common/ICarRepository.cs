namespace PariPlayCars.Data.Common
{
    using PariPlayCars.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface ICarRepository : IGenericRepository<Car>
    {
        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<TEntity> GetByIdAsync(string id);

        Task<TEntity> Update(TEntity entity);

        Task<TEntity> Add(TEntity entity);

        Task<TEntity> Remove(TEntity entity);
    }
}
