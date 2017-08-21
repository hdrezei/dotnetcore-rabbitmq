using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using nyom.domain;
using nyom.domain.core.EntityFramework.Interfaces;
using nyom.infra.Data.EntityFramwork.Context;

namespace nyom.infra.Data.EntityFramwork.Repositories
{
    public  class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : BaseEntity
    {
        private readonly IDbContext _context;
        protected DbSet<TEntity> DbSet;

        public RepositoryBase(IDbContext context)
        {
            _context = context;
            DbSet = context.Set<TEntity>();
        }

       // public DbSet<TEntity> Entities => _entities ?? (_entities = _context.Set<TEntity>());

        //public  IQueryable<TEntity> Table => Entities;

        public  ICollection<TEntity> All()
        {
            return DbSet.AsTracking().ToList();
        }

        public  bool Delete(Guid id)
        {
            return Delete(Get(id));
        }

        public  bool Delete(TEntity entity)
        {
            DbSet.Remove(entity);
            return true;
        }

        public  void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public  TEntity Find(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate).AsTracking().SingleOrDefault();
        }

        public  ICollection<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate).AsTracking().ToList();
        }

        public  TEntity Get(Guid id)
        {
            return DbSet.Find(id);
        }

        public   TEntity Update(TEntity obj)
        {
            // var entry = _context.Entry(obj);
            //_entities.Attach(obj);
            //entry.State = EntityState.Modified;
            //return obj;

            if (obj == null)
                throw new ArgumentNullException("obj");

            _context.SaveChanges();
            return obj;
        }

        public  TEntity Save(TEntity entity)
        {
            DbSet.Add(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}