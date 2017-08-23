using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using nyom.domain.Crm.Templates;
using nyom.infra.Data.EntityFramwork.Extensions;

namespace nyom.infra.Data.EntityFramwork.Mappings.Crm
{
	public class TemplateMap : EntityTypeConfiguration<Template>
	{
		public override void Map(EntityTypeBuilder<Template> builder)
		{
			builder.HasKey(c => c.TemplateId);

			builder.Property(c => c.TemplateId)
				.HasColumnName("TemplateId");

			builder.Property(c => c.DataCriacao)
				.IsRequired();

			builder.Property(c => c.Nome)
				.IsRequired()
				.HasMaxLength(100)
				.HasColumnType("varchar(100)");

			builder.Property(c => c.Mensagem)
				.IsRequired()
				.HasMaxLength(100)
				.HasColumnType("varchar(100)");

			builder.Property(c => c.Status)
				.IsRequired();
		}
	}
}
