using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using nyom.domain.Crm.Campanha;
using nyom.infra.Data.EntityFramwork.Extensions;

namespace nyom.infra.Data.EntityFramwork.Mappings.Workflow
{
	public class CampanhaMap : EntityTypeConfiguration<Campanha>
	{
		public override void Map(EntityTypeBuilder<Campanha> builder)
		{
			builder.Property(c => c.CampanhaId)
				.HasColumnName("CampanhaId");

			builder.Property(c => c.DataInicio)
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
