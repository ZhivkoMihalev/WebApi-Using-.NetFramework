namespace Repositories.GenericRepo
{
    using PariPlayCars.Data;
    using System;
    using System.Data.Entity;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity>, IDisposable
        where TEntity : class
    {
        private IDbSet<TEntity> _entities;
        private bool _isDisposed;

        protected GenericRepository(PariPlayCarsDbContext context)
        {
            _isDisposed = false;
            this.Context = context;
        }

        public PariPlayCarsDbContext Context { get; set; }

        protected virtual IDbSet<TEntity> Entities
            => this._entities ?? (_entities = this.Context.Set<TEntity>());

        public void Add(TEntity entity)
        {
            if (this.Context == null || this._isDisposed)
            {
                this.Context = new PariPlayCarsDbContext();
            }

            this.Entities.Add(entity);
        }

        public void Dispose()
        {
            if (this.Context != null)
            {
                this.Context.Dispose();
                this._isDisposed = true;
            }
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
            => await this.Entities.ToListAsync();

        public virtual async Task<TEntity> GetByIdAsync(string id)
            => await this.Entities.SingleAsync();

        public virtual void Remove(TEntity entity)
        {
            if (this.Context == null || this._isDisposed)
            {
                this.Context = new PariPlayCarsDbContext();
            }

            this.Entities.Remove(entity);
        }

        public async Task SaveChangesAsync()
        {
            await this.Context.SaveChangesAsync();
        }
    }
}
