using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TODOListApplication.Data
{
    public interface IGenericRepository
    {

        TObject Get<TObject>(int id) where TObject : class, IBaseDbEntity;
        Task<TObject> GetAsync<TObject>(int id) where TObject : class, IBaseDbEntity;
        TObject FirstOrDefault<TObject>(Expression<Func<TObject, bool>> match) where TObject : class, IBaseDbEntity;
        IQueryable<TObject> Where<TObject>(Expression<Func<TObject, bool>> match) where TObject : class, IBaseDbEntity;
        IQueryable<TEntity> Where<TEntity>() where TEntity : class, IBaseDbEntity;
        TObject Add<TObject>(TObject t) where TObject : class, IBaseDbEntity;
        TObject AddOrUpdate<TObject>(TObject t, int key = 0) where TObject : class, IBaseDbEntity;

        int Count<TObject>() where TObject : class, IBaseDbEntity;
        Task<int> CountAsync<TObject>() where TObject : class, IBaseDbEntity;
        int Count<TObject>(Expression<Func<TObject, bool>> match) where TObject : class, IBaseDbEntity;
        Task<int> CountAsync<TObject>(Expression<Func<TObject, bool>> match) where TObject : class, IBaseDbEntity;
        Task<int> SaveChangesAsync();
        int SaveChanges();
        bool HardDelete<TObject>(int key) where TObject : class, IBaseDbEntity;

        IDisposable BeginTransaction();
        void Commit();
        void Rollback();
    }
}
