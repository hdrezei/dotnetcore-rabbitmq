using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using nyom.domain.Crm.Notifications;
using nyom.infra.Data.EntityFramwork.Extensions;

namespace nyom.infra.Data.EntityFramwork.Mappings.Crm
{
    public class NotificationMap : EntityTypeConfiguration<Notification>
	{
		public override void Map(EntityTypeBuilder<Notification> builder)
		{
			builder.Property(c => c.NotificationId)
				.IsRequired();

			builder.Property(c => c.Cadastrado)
				.IsRequired();

			builder.Property(c => c.CodigoAplicativo)
				.IsRequired();

			builder.Property(c => c.CodigoNotificacao)
				.IsRequired();

			builder.Property(c => c.CodigoTemplate)
				.IsRequired();

			builder.Property(c => c.Contexto)
				.HasColumnType("varchar(100)")
				.HasMaxLength(100)
				.IsRequired();

			builder.Property(c => c.IdServidor)
				.IsRequired();

			builder.Property(c => c.MaxRegistros)
				.IsRequired();

			builder.Property(c=>c.NomeRobo)
				.HasColumnType("varchar(100)")
				.HasMaxLength(100)
				.IsRequired();

			builder.Property(c => c.Plataforma)
				.IsRequired();

			builder.Property(c=>c.ThreadName)
				.HasColumnType("varchar(100)")
				.HasMaxLength(100)
				.IsRequired();

			builder.Property(c=>c.TokenPush)
				.HasColumnType("varchar(100)")
				.HasMaxLength(100)
				.IsRequired();
			
		}
	}
}
