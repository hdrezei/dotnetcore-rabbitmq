using nyom.domain.core.Interfaces;
using nyom.domain.core.Models;

namespace nyom.domain.Templates
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