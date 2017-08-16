using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using nyom.domain.Crm.Campanha;
using nyom.infra.Data.EntityFramwork.Extensions;

namespace nyom.infra.Data.EntityFramwork.Mappings.Crm
{
	public class CampanhaMap : EntityTypeConfiguration<CampanhaCrm>
	{
		public override void Map(EntityTypeBuilder<CampanhaCrm> builder)
		{
			builder.Property(c => c.CampanhaId)
				.HasColumnName("CampanhaId");

			builder.Property(c => c.DataInicio)
				.IsRequired();

			builder.Property(c => c.DataCriacao)
				.IsRequired();

			builder.Property(c => c.Nome)
				.IsRequired()
				.HasMaxLength(100)
				.HasColumnType("varchar(100)");

			builder.Property(c => c.Status)
				.IsRequired();

			builder.Property(c => c.TemplateId)
				.IsRequired();

			builder.Property(c => c.Publico)
				.IsRequired();
		}
	}
}
