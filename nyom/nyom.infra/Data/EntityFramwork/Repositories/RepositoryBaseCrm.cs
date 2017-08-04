﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using nyom.infra.Data.EntityFramwork.Context;
using nyom.domain.core.Interfaces;

namespace nyom.infra.Data.EntityFramwork.Repositories
{
	public class RepositoryBaseCrm<TEntity> : IRepositoryBase<TEntity> where TEntity : class
	{
		protected CrmContext Db;
		protected DbSet<TEntity> DbSet;

		public RepositoryBaseCrm(CrmContext context)
		{
			Db = context;
			DbSet = Db.Set<TEntity>();
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

		public TEntity Save(TEntity entity)
		{
			DbSet.Add(entity);
			Db.SaveChanges();
			return entity;
		}
	}
}