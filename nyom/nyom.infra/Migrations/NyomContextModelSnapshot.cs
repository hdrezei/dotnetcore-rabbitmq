using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using nyom.infra.Data.EntityFramwork.Context;

namespace nyom.infra.Migrations
{
    [DbContext(typeof(NyomContext))]
    partial class NyomContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("nyom.domain.Configuration.Configuration", b =>
                {
                    b.Property<Guid>("ConfigurationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ConfigurationId");

                    b.Property<bool>("AutoScaleChannels");

                    b.Property<int>("Channels");

                    b.Property<bool>("ConexaoAtiva");

                    b.Property<int>("ConnectionTimeout");

                    b.Property<int>("FeedbackIntervalMinutes");

                    b.Property<DateTime>("HoraFim");

                    b.Property<DateTime>("HoraInicio");

                    b.Property<int>("IdMaquina");

                    b.Property<int>("IdleTimeOut");

                    b.Property<int>("MaxAutoScaleChannels");

                    b.Property<int>("MaxConnectionAttempts");

                    b.Property<int>("MaxNotificationRequeues");

                    b.Property<int>("MillisecondsToWaitBeforeMessageDeclaredSuccess");

                    b.Property<int>("MinAvgTimeToScaleChannels");

                    b.Property<int>("NotificationSendTimeout");

                    b.Property<int>("QuantidadeEnvio");

                    b.Property<int>("TempoProcessamento");

                    b.Property<string>("TipoRobo")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<bool>("UsaSandBox");

                    b.HasKey("ConfigurationId");

                    b.ToTable("Configurations");
                });

            modelBuilder.Entity("nyom.domain.Notifications.Notification", b =>
                {
                    b.Property<Guid>("NotificationId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Cadastrado");

                    b.Property<int>("CodigoAplicativo");

                    b.Property<int>("CodigoNotificacao");

                    b.Property<int>("CodigoTemplate");

                    b.Property<string>("Contexto")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("IdServidor");

                    b.Property<int>("MaxRegistros");

                    b.Property<string>("NomeRobo")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("Plataforma");

                    b.Property<string>("ThreadName")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("TokenPush")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("NotificationId");

                    b.ToTable("Notifications");
                });
        }
    }
}
