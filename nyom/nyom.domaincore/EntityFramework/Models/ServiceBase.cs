using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using nyom.domain.core.EntityFramework.Interfaces;

namespace nyom.domain.core.EntityFramework.Models
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repositoryBase;

        public ServiceBase(IRepositoryBase<TEntity> repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }

        public  void Dispose()
        {
            _repositoryBase.Dispose();
        }

        public  TEntity Get(Guid id)
        {
           return _repositoryBase.Get(id);
        }

        public  TEntity Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _repositoryBase.Find(predicate);
        }

        public  IEnumerable<TEntity> All()
        {
            return _repositoryBase.All();
        }

        public  IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate)
        {
            return _repositoryBase.FindAll(predicate);
        }

        public  TEntity Save(TEntity entity)
        {
          return _repositoryBase.Save(entity);
        }

        public  bool Delete(Guid id)
        {
            return _repositoryBase.Delete(id);
        }

        public  bool Delete(TEntity entity)
        {
         return   _repositoryBase.Delete(entity);
        }

        public  TEntity Update(TEntity entity)
        {
            return _repositoryBase.Update(entity);
        }
    }
}