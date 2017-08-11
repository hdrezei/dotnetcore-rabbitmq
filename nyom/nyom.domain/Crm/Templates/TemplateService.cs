using nyom.domain.core.EntityFramework.Models;
using nyom.domain.core.Models;

namespace nyom.domain.Crm.Templates
{
	public class TemplateService : ServiceBaseCrm<Template>,ITemplateService
	{
		private readonly ITemplateRepository _templateRepository;
		public TemplateService(ITemplateRepository templateRepository) : base(templateRepository)
		{
			_templateRepository = templateRepository;
		}
	}
}