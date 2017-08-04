using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using nyom.domain.Workflow.Workflow;
using nyom.infra.Data.EntityFramwork.Extensions;

namespace nyom.infra.Data.EntityFramwork.Mappings
{
	public class WorkflowMap : EntityTypeConfiguration<Workflow>
	{
		public override void Map(EntityTypeBuilder<Workflow> builder)
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