using Microsoft.EntityFrameworkCore;
using nyom.domain;

namespace nyom.infra.Data.EntityFramwork.Context
{
    public interface IDbContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity;
        int SaveChanges();
    }
}