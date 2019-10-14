using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TODOListApplication.Data
{
    public class EfGenericRepository<TContext> : IGenericRepository, IDisposable where TContext : DbContext, new()
    {
        private bool _disposed = false;

        internal TContext Context;
        public EfGenericRepository(TContext context)
        {
            Context = context;
            //TODO-> Bu muhakkak yapılacak
            //context.Configuration.LazyLoadingEnabled = false;
            //context.Configuration.ProxyCreationEnabled = false;
        }

        public TObject Get<TObject>(int id) where TObject : class, IBaseDbEntity
        {
            return Context.Set<TObject>().Find(id);
        }

        public async Task<TObject> GetAsync<TObject>(int id) where TObject : class, IBaseDbEntity
        {
            return await Context.Set<TObject>().FindAsync(id);
        }


        public TObject FirstOrDefault<TObject>(Expression<Func<TObject, bool>> match) where TObject : class, IBaseDbEntity
        {
            return Context.Set<TObject>().FirstOrDefault(match);
        }


        public IQueryable<TObject> Where<TObject>(Expression<Func<TObject, bool>> match) where TObject : class, IBaseDbEntity
        {
            return Context.Set<TObject>().Where(match);
        }

        public IQueryable<TObject> Where<TObject>() where TObject : class, IBaseDbEntity
        {
            return Context.Set<TObject>();
        }

        public TObject Add<TObject>(TObject t) where TObject : class, IBaseDbEntity
        {
            return Context.Set<TObject>().Add(t);
        }

        public bool HardDelete<TObject>(int key) where TObject : class, IBaseDbEntity
        {
            TObject existing = Context.Set<TObject>().Find(key);
            Context.Entry(existing).State = EntityState.Deleted;
            Context.SaveChanges();


            return true;
        }

        public TObject AddOrUpdate<TObject>(TObject t, int key = 0) where TObject : class, IBaseDbEntity
        {
            if (t == null)
                return null;

            if (key > 0)
            {
                TObject existing = Context.Set<TObject>().Find(key);
                if (existing != null)
                {
                    Context.Entry(existing).CurrentValues.SetValues(t);
                }
                return existing;
            }
            else
            {
                Context.Set<TObject>().Add(t);
                return t;
            }
        }

    
        public int Count<TObject>() where TObject : class, IBaseDbEntity
        {
            return Context.Set<TObject>().Count();
        }

        public async Task<int> CountAsync<TObject>() where TObject : class, IBaseDbEntity
        {
            return await Context.Set<TObject>().CountAsync();
        }

        public int Count<TObject>(Expression<Func<TObject, bool>> match) where TObject : class, IBaseDbEntity
        {
            return Context.Set<TObject>().Count(match);
        }

        public async Task<int> CountAsync<TObject>(Expression<Func<TObject, bool>> match) where TObject : class, IBaseDbEntity
        {
            return await Context.Set<TObject>().CountAsync(match);
        }

        public async Task<int> SaveChangesAsync()
        {
            if (!Context.ChangeTracker.Entries().Any(p => p.State == EntityState.Modified || p.State == EntityState.Deleted || p.State == EntityState.Added))
                return 1;
            return await Context.SaveChangesAsync();
        }

        public int SaveChanges()
        {
            if (!Context.ChangeTracker.Entries().Any(p => p.State == EntityState.Modified || p.State == EntityState.Deleted || p.State == EntityState.Added))
                return 1;
            return Context.SaveChanges();
        }

        private DbContextTransaction _transactionInformation;
        private IGenericRepository _genericRepositoryImplementation;

        public IDisposable BeginTransaction()
        {
            return _transactionInformation = Context.Database.BeginTransaction();
        }

        public void Commit()
        {
            _transactionInformation.Commit();
        }

        public void Rollback()
        {
            _transactionInformation.Rollback();
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                if (_transactionInformation != null)
                {
                    _transactionInformation.Rollback();
                    _transactionInformation.Dispose();
                }
                Context?.Dispose();
            }
            _disposed = true;
        }
    }
}
