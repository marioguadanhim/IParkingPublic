using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using IParking.Domain.Interfaces.Base;
using IParking.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace IParking.Infra.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected IParkingContext Db;
        protected DbSet<TEntity> DbSet;

        public Repository(IParkingContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public virtual TEntity Insert(TEntity obj)
        {
            var objreturn = DbSet.Add(obj);
            return objreturn?.Entity;
        }

        public virtual TEntity FindById(Guid id)
        {
            return DbSet.Find(id);
        }

        public virtual TEntity FindById(int id)
        {
            return DbSet.Find(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return DbSet.ToList();
        }

        public virtual TEntity Update(TEntity obj)
        {
            var entry = Db.Entry(obj);
            DbSet.Attach(obj);
            entry.State = EntityState.Modified;

            return obj;
        }

        public virtual void Remove(Guid id)
        {
            DbSet.Remove(FindById(id));
        }

        public virtual void Remove(int id)
        {
            DbSet.Remove(FindById(id));
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
