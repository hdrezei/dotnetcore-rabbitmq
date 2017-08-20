using Microsoft.EntityFrameworkCore;
using nyom.domain;

namespace nyom.infra
{
    public interface IDbContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity;
        int SaveChanges();
    }
}