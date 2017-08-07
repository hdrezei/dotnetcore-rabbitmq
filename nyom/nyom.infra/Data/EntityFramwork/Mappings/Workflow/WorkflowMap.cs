using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using nyom.infra.Data.EntityFramwork.Extensions;
using nyom.domain.Workflow.Workflow;

namespace nyom.infra.Data.EntityFramwork.Mappings.Workflow
{
	public class WorkflowMap : EntityTypeConfiguration<domain.Workflow.Workflow.Workflow>
	{
		public override void Map(EntityTypeBuilder<domain.Workflow.Workflow.Workflow> builder)
		{
			builder.Property(c => c.WorkflowId)
				.HasColumnName("WorkflowId");

			builder.Property(c => c.CampanhaId)
				.IsRequired();

			builder.Property(c => c.TemplateId)
				.IsRequired();

			builder.Property(c => c.Status)
				.IsRequired();
		}
	}
}