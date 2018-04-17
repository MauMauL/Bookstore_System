using Bookstore_System.Application.Interface;
using Bookstore_System.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace Bookstore_System.Application
{
    public class AppServiceBase<TEntity> : IDisposable, IAppServiceBase<TEntity> where TEntity : class
    {
        private readonly IServiceBase<TEntity> _ServiceBase;

        public AppServiceBase(IServiceBase<TEntity> ServiceBase)
        {
            _ServiceBase = ServiceBase;
        }

        public void Add(TEntity obj)
        {
            _ServiceBase.Add(obj);
        }

        public void Dispose()
        {
            _ServiceBase.Dispose();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _ServiceBase.GetAll();
        }

        public TEntity GetById(int id)
        {
            return _ServiceBase.GetById(id);
        }

        public void Remove(TEntity obj)
        {
            _ServiceBase.Remove(obj);
        }

        public void Update(TEntity obj)
        {
            _ServiceBase.Update(obj);
        }
    }
}
