namespace PizzaLab.Data
{
    using PariPlayCars.Data;
    using PariPlayCars.Data.Common;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Threading.Tasks;

    public class EfRepository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        public EfRepository(PariPlayCarsDbContext context)
        {
            this.Context = context ?? throw new ArgumentNullException(nameof(context));
            this.DbSet = this.Context.Set<TEntity>();
        }

        protected DbSet<TEntity> DbSet { get; set; }

        protected PariPlayCarsDbContext Context { get; set; }

        public async Task<IEnumerable<TEntity>> All() => await this.DbSet.ToListAsync();

        public async Task<TEntity> GetByIdAsync(string id) => await this.DbSet.FindAsync(id);

        public async Task<TEntity> Add(TEntity entity)
        {
            TEntity result;
            if (entity != null)
            {
                result = this.DbSet.Add(entity);
                await this.SaveChangesAsync();
                return result;
            }

            else
            {
                return null;
            }
        }

        public async Task<TEntity> Remove(TEntity entity)
        {
            var result = this.DbSet.Remove(entity);
            await this.SaveChangesAsync();
            return result;
        }

        public Task<int> SaveChangesAsync() => this.Context.SaveChangesAsync();

        public void Dispose() => this.Context.Dispose();
    }
}
