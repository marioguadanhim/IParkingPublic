using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace IParking.Domain.Interfaces.Base
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        TEntity Insert(TEntity obj);
        TEntity FindById(Guid id);
        TEntity FindById(int id);
        IEnumerable<TEntity> GetAll();
        TEntity Update(TEntity obj);
        void Remove(Guid id);
        void Remove(int id);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        int SaveChanges();
    }
}
