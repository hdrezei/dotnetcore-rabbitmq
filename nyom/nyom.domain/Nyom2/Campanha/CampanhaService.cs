using nyom.domain.core.Models;

namespace nyom.domain.Nyom2.Campanha
{
	public class CampanhaService : ServiceBase<Campanha> , ICampanhaService
	{
		private readonly ICampanhaRepository _campanhaRepository;
		public CampanhaService(ICampanhaRepository campanhaRepository) : base(campanhaRepository)
		{
			_campanhaRepository = campanhaRepository;
		}
	}
}