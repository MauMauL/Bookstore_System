using Bookstore_System.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Bookstore_System.Infrastructure.Data.Repositories
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected Bookstore_SystemContext bsc = new Bookstore_SystemContext();   

        public void Add(TEntity obj)
        {
            bsc.Set<TEntity>().Add(obj);
            bsc.SaveChanges();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return bsc.Set<TEntity>().ToList();
        }

        public TEntity GetById(int id)
        {
            return bsc.Set<TEntity>().Find(id);
        }

        public void Remove(TEntity obj)
        {
            bsc.Set<TEntity>().Remove(obj);
            bsc.SaveChanges();
        }

        public void Update(TEntity obj)
        {
            bsc.Entry(obj).State = EntityState.Modified;
            bsc.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
