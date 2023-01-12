namespace Repositories.GenericRepo
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IGenericRepository<TEntity>
        where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<TEntity> GetByIdAsync(string id);

        void Add(TEntity entity);

        void Remove(TEntity entity);
    }
}
