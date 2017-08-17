using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using nyom.domain.Crm.Pessoa;
using nyom.infra.Data.EntityFramwork.Extensions;

namespace nyom.infra.Data.EntityFramwork.Mappings.Crm
{
	public class PessoaMap : EntityTypeConfiguration<Pessoa>
	{
		public override void Map(EntityTypeBuilder<Pessoa> builder)
		{
			builder.HasKey(c => c.PessoaId);

			builder.Property(c => c.PessoaId)
				.HasColumnName("PessoaId");

			builder.Property(c => c.Bairro)
				.IsRequired()
				.HasMaxLength(100)
				.HasColumnType("varchar(100)");

			builder.Property(c => c.CEP)
				.IsRequired()
				.HasMaxLength(8)
				.HasColumnType("varchar(8)");

			builder.Property(c => c.CPF)
				.IsRequired()
				.HasMaxLength(11)
				.HasColumnType("varchar(11)");

			builder.Property(c => c.Cidade)
				.IsRequired()
				.HasMaxLength(100)
				.HasColumnType("varchar(100)");

			builder.Property(c => c.DataNascimento)
				.IsRequired();

			builder.Property(c => c.Email)
				.IsRequired()
				.HasMaxLength(100)
				.HasColumnType("varchar(100)");

			builder.Property(c => c.Endereco)
				.IsRequired()
				.HasMaxLength(100)
				.HasColumnType("varchar(100)");

			builder.Property(c => c.Estado)
				.IsRequired()
				.HasMaxLength(100)
				.HasColumnType("varchar(100)");

			builder.Property(c => c.Nome)
				.IsRequired()
				.HasMaxLength(100)
				.HasColumnType("varchar(100)");

			builder.Property(c => c.Sobrenome)
				.IsRequired()
				.HasMaxLength(100)
				.HasColumnType("varchar(100)");

			builder.Property(c => c.Telefone)
				.IsRequired()
				.HasMaxLength(11)
				.HasColumnType("varchar(11)");
		}
	}
}
