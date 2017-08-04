using nyom.domain.core.Models;

namespace nyom.domain.Crm.Templates
{
	public class TemplateService : ServiceBase<Template>,ITemplateService
	{
		private readonly ITemplateRepository _templateRepository;
		public TemplateService(ITemplateRepository templateRepository) : base(templateRepository)
		{
			_templateRepository = templateRepository;
		}
	}
}