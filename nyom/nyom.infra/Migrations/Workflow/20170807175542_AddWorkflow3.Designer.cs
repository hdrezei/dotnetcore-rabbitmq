using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using nyom.infra.Data.EntityFramwork.Context;

namespace nyom.infra.Migrations.Workflow
{
    [DbContext(typeof(WorkflowContext))]
    [Migration("20170807175542_AddWorkflow3")]
    partial class AddWorkflow3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("nyom.domain.Crm.Campanha.Campanha", b =>
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

            modelBuilder.Entity("nyom.domain.Workflow.Workflow.Workflow", b =>
                {
                    b.Property<Guid>("WorkflowId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("WorkflowId");

                    b.Property<Guid>("CampanhaId");

                    b.Property<int>("Status");

                    b.Property<Guid>("TemplateId");

                    b.HasKey("WorkflowId");

                    b.ToTable("Workflows");
                });
        }
    }
}
