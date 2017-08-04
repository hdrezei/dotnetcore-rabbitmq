using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using nyom.domain.core.Interfaces;
using nyom.infra.Data.EntityFramwork.Context;

namespace nyom.infra.Data.EntityFramwork.Repositories
{
    public class RepositoryBaseWorkflow<TEntity> : IRepositoryBase<TEntity> where TEntity : class
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
		    throw new NotImplementedException();
	    }

	    public TEntity Get(Guid id)
	    {
		    throw new NotImplementedException();
	    }

	    public TEntity Find(Expression<Func<TEntity, bool>> predicate)
	    {
		    throw new NotImplementedException();
	    }

	    public ICollection<TEntity> All()
	    {
		    throw new NotImplementedException();
	    }

	    public ICollection<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate)
	    {
		    throw new NotImplementedException();
	    }

	    public TEntity Save(TEntity entity)
	    {
		    throw new NotImplementedException();
	    }

	    public bool Delete(Guid id)
	    {
		    throw new NotImplementedException();
	    }

	    public bool Delete(TEntity entity)
	    {
		    throw new NotImplementedException();
	    }
    }
}
