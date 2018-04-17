using Bookstore_System.Domain.Interfaces.Repositories;
using Bookstore_System.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace Bookstore_System.Domain.Services
{
    public class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _RepositoryBase;

        public ServiceBase(IRepositoryBase<TEntity> RepositoryBase)
        {
            _RepositoryBase = RepositoryBase;
        }

        public void Add(TEntity obj)
        {
            _RepositoryBase.Add(obj);
        }

        public void Dispose()
        {
            _RepositoryBase.Dispose();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _RepositoryBase.GetAll();
        }

        public TEntity GetById(int id)
        {
            return _RepositoryBase.GetById(id);
        }

        public void Remove(TEntity obj)
        {
            _RepositoryBase.Remove(obj);
        }

        public void Update(TEntity obj)
        {
            _RepositoryBase.Dispose();
        }
    }
}
