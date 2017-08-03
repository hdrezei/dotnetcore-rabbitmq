using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using nyom.infra.Data.EntityFramwork.Context;

namespace nyom.infra.Migrations
{
    [DbContext(typeof(NyomContext))]
    [Migration("20170803195642_03062017")]
    partial class _03062017
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("nyom.domain.Campanha.Campanha", b =>
                {
                    b.Property<Guid>("CampanhaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CampanhaId");

                    b.Property<DateTime>("DataInicio");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<bool>("Status");

                    b.Property<Guid>("TemplateId");

                    b.HasKey("CampanhaId");

                    b.ToTable("Campanhas");
                });

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

            modelBuilder.Entity("nyom.domain.Empresa.Empresa", b =>
                {
                    b.Property<Guid>("EmpresaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("EmpresaId");

                    b.Property<string>("CNPJ")
                        .IsRequired();

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("RazaoSocial")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Telefone")
                        .IsRequired();

                    b.HasKey("EmpresaId");

                    b.ToTable("Empresas");
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

            modelBuilder.Entity("nyom.domain.Pessoa.Pessoa", b =>
                {
                    b.Property<Guid>("PessoaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("PessoaId");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasColumnType("varchar(8)")
                        .HasMaxLength(8);

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("varchar(11)")
                        .HasMaxLength(11);

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime>("DataNascimento");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("varchar(11)")
                        .HasMaxLength(11);

                    b.HasKey("PessoaId");

                    b.ToTable("Pessoas");
                });

            modelBuilder.Entity("nyom.domain.Templates.Template", b =>
                {
                    b.Property<Guid>("TemplateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("TemplateId");

                    b.Property<DateTime>("DataCriacao");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<bool>("Status");

                    b.HasKey("TemplateId");

                    b.ToTable("Templates");
                });

            modelBuilder.Entity("nyom.domain.Workflow.Workflow", b =>
                {
                    b.Property<Guid>("WorkflowId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("WorkflowId");

                    b.Property<Guid>("CampanhaId");

                    b.Property<bool>("Status");

                    b.Property<Guid>("TemplateId");

                    b.HasKey("WorkflowId");

                    b.ToTable("Workflows");
                });
        }
    }
}
