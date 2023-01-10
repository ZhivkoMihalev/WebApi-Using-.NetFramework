namespace Repositories.GenericRepo
{
    using PariPlayCars.Data;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Validation;
    using System.Linq;
    using System.Threading.Tasks;

    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity>, IDisposable
        where TEntity : class
    {
        private IDbSet<TEntity> _entities;
        private string _errorMessage = string.Empty;
        private bool _isDisposed;

        //public GenericRepository(IAbstractDbContext<PariPlayCarsDbContext> abstractDbContext)
        //    : this(abstractDbContext.Context)
        //{
        //}

        public GenericRepository(PariPlayCarsDbContext context)
        {
            _isDisposed = false;
            this.Context = context;
        }

        public PariPlayCarsDbContext Context { get; set; }

        public virtual IQueryable<TEntity> Table => this.Entities;

        protected virtual IDbSet<TEntity> Entities
            => this._entities ?? (_entities = this.Context.Set<TEntity>());

        public void Add(TEntity entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("The entity is null");
                }

                if (this.Context == null || this._isDisposed)
                {
                    this.Context = new PariPlayCarsDbContext();
                }

                this.Entities.Add(entity);
                //await this.Context.SaveChangesAsync();
            }

            catch (DbEntityValidationException ex)
            {
                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        this._errorMessage += string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;
                        throw new Exception(this._errorMessage, ex);
                    }
                }
            }
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
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("The entity is null.");
                }

                if (this.Context == null || this._isDisposed)
                {
                    this.Context = new PariPlayCarsDbContext();
                }

                this.Entities.Remove(entity);
                //await this.Context.SaveChangesAsync();
            }

            catch (DbEntityValidationException ex)
            {
                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        this._errorMessage += string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;
                        throw new Exception(this._errorMessage, ex);
                    }
                }
            }
        }

        public virtual void SetEntryModified(TEntity entity)
        {
            this.Context.Entry(entity).State = EntityState.Modified;
        }

        public async Task SaveChangesAsync()
        {
            await this.Context.SaveChangesAsync();
        }
    }
}
