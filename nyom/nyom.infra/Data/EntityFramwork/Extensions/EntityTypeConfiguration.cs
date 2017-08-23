using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace nyom.infra.Data.EntityFramwork.Extensions
{
	public abstract class EntityTypeConfiguration<TEntity> where TEntity : class
	{
		public abstract void Map(EntityTypeBuilder<TEntity> builder);
	}
}
