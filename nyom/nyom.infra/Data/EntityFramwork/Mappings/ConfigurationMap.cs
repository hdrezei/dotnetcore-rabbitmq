using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using nyom.domain.Nyom.Configuration;
using nyom.infra.Data.EntityFramwork.Extensions;

namespace nyom.infra.Data.EntityFramwork.Mappings
{
	public class ConfigurationMap : EntityTypeConfiguration<Configuration>
	{
		public override void Map(EntityTypeBuilder<Configuration> builder)
		{
			builder.Property(c => c.ConfigurationId)
				.HasColumnName("ConfigurationId");

			builder.Property(c => c.TempoProcessamento)
				.IsRequired();

			builder.Property(c => c.QuantidadeEnvio)
				.IsRequired();

			builder.Property(c => c.AutoScaleChannels)
				.IsRequired();

			builder.Property(c => c.Channels)
				.IsRequired();

			builder.Property(c => c.ConexaoAtiva)
				.IsRequired();

			builder.Property(c => c.ConnectionTimeout)
				.IsRequired();

			builder.Property(c => c.FeedbackIntervalMinutes)
				.IsRequired();

			builder.Property(c => c.HoraFim)
				.IsRequired();

			builder.Property(c => c.HoraInicio)
				.IsRequired();

			builder.Property(c => c.IdMaquina)
				.IsRequired();

			builder.Property(c => c.IdleTimeOut)
				.IsRequired();

			builder.Property(c => c.MaxAutoScaleChannels)
				.IsRequired();

			builder.Property(c => c.MaxConnectionAttempts)
				.IsRequired();

			builder.Property(c => c.MaxNotificationRequeues)
				.IsRequired();

			builder.Property(c => c.MillisecondsToWaitBeforeMessageDeclaredSuccess)
				.IsRequired();

			builder.Property(c => c.MinAvgTimeToScaleChannels)
				.IsRequired();

			builder.Property(c => c.NotificationSendTimeout)
				.IsRequired();

			builder.Property(c => c.QuantidadeEnvio)
				.IsRequired();

			builder.Property(c => c.TempoProcessamento)
				.IsRequired();

			builder.Property(c => c.TipoRobo)
				.HasColumnType("varchar(100)")
				.HasMaxLength(100)
				.IsRequired();
		}
	}
}
