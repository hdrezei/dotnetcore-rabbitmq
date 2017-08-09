using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using nyom.domain.core.Interfaces;
using nyom.infra.Data.EntityFramwork.Context;

namespace nyom.infra.Data.EntityFramwork.Repositories
{
    public class RepositoryBaseWorkflow<TEntity> : IRepositoryBaseWorkflow<TEntity> where TEntity : class
    {
	    
	    protected WorkflowContext Db;
	    protected DbSet<TEntity> DbSet;

	    public RepositoryBaseWorkflow(WorkflowContext context)
	    {
		    Db = context;
		    DbSet = Db.Set<TEntity>();
	    }

	    public void Dispose()
	    {
			GC.SuppressFinalize(this);
		}

	    public TEntity Get(Guid id)
	    {
			return DbSet.Find(id);
		}

	    public TEntity Find(Expression<Func<TEntity, bool>> predicate)
	    {
			return DbSet.Where(predicate).AsTracking().SingleOrDefault();
		}

	    public ICollection<TEntity> All()
	    {
			return DbSet.AsTracking().ToList();
		}

	    public ICollection<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate)
	    {
			return DbSet.Where(predicate).AsTracking().ToList();
		}

	    public TEntity Save(TEntity entity)
	    {
			DbSet.Add(entity);
		    Db.SaveChanges();
		    return entity;
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
	    public virtual TEntity Update(TEntity obj)
	    {
		    var entry = Db.Entry(obj);
		    DbSet.Attach(obj);
		    entry.State = EntityState.Modified;
		    return obj;
	    }
	}
}
