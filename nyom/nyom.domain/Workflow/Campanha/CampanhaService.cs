using nyom.domain.core.Models;

namespace nyom.domain.Workflow.Campanha
{
	public class CampanhaService : ServiceBaseWorkflow<domain.Workflow.Campanha.Campanha> , ICampanhaService
	{
		private readonly ICampanhaRepository _campanhaRepository;
		public CampanhaService(ICampanhaRepository campanhaRepository) : base(campanhaRepository)
		{
			_campanhaRepository = campanhaRepository;
		}
	}
}