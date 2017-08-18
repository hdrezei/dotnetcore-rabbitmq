

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using nyom.domain.core.EntityFramework.Interfaces;
using nyom.infra.Data.EntityFramwork.Context;

namespace nyom.infra.Data.EntityFramwork.Repositories
{
	public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
	{
		
		protected DbSet<TEntity> DbSet;
		protected readonly CrmContext _context;
		public RepositoryBase(IOptions<ContextSettings>settings)
		{
			//Db = context;
			//DbSet = Db.Set<TEntity>();
			_context = new CrmContext(settings);
		}

		public ICollection<TEntity> All()
		{
			return DbSet.AsTracking().ToList();
		}

		public bool Delete(Guid id)
		{
			return Delete(Get(id));
		}

		public bool Delete(TEntity entity)
		{
			DbSet.Remove(entity);
			return true;
		}

		public void Dispose()
		{
			GC.SuppressFinalize(this);
		}

		public TEntity Find(Expression<Func<TEntity, bool>> predicate)
		{
			return DbSet.Where(predicate).AsTracking().SingleOrDefault();
		}

		public ICollection<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate)
		{
			return DbSet.Where(predicate).AsTracking().ToList();
		}

		public TEntity Get(Guid id)
		{
			return DbSet.Find(id);
		}

		public virtual TEntity Update(TEntity obj)
		{
			var entry = Db.Entry(obj);
			DbSet.Attach(obj);
			entry.State = EntityState.Modified;
			return obj;
		}


		public TEntity Save(TEntity entity)
		{
			DbSet.Add(entity);
			Db.SaveChanges();
			return entity;
		}
	}
}