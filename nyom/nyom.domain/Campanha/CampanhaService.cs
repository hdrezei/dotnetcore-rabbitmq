using nyom.domain.core.Interfaces;
using nyom.domain.core.Models;

namespace nyom.domain.Campanha
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