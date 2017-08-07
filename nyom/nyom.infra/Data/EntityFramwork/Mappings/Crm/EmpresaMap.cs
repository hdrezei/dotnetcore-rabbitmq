using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using nyom.domain.Crm.Empresa;
using nyom.infra.Data.EntityFramwork.Extensions;

namespace nyom.infra.Data.EntityFramwork.Mappings
{
	public class EmpresaMap : EntityTypeConfiguration<Empresa>
	{
		public override void Map(EntityTypeBuilder<Empresa> builder)
		{
			builder.Property(c => c.EmpresaId)
				.HasColumnName("EmpresaId");

			builder.Property(c => c.CNPJ)
				.IsRequired();

			builder.Property(c => c.Nome)
				.IsRequired()
				.HasMaxLength(100)
				.HasColumnType("varchar(100)");

			builder.Property(c => c.Email)
				.IsRequired()
				.HasMaxLength(100)
				.HasColumnType("varchar(100)");

			builder.Property(c => c.RazaoSocial)
				.IsRequired()
				.HasMaxLength(100)
				.HasColumnType("varchar(100)");

			builder.Property(c => c.Telefone)
				.IsRequired();
		}
	}
}
