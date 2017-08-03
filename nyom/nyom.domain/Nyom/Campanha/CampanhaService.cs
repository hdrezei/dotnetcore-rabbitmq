using nyom.domain.core.Interfaces;
using nyom.domain.core.Models;
using nyom.domain.Nyom.Campanha;

namespace nyom.domain.Nyom.Campanha
{
	public class CampanhaService : ServiceBase<Nyom.Campanha.Campanha> , ICampanhaService
	{
		private readonly ICampanhaRepository _campanhaRepository;
		public CampanhaService(ICampanhaRepository campanhaRepository) : base(campanhaRepository)
		{
			_campanhaRepository = campanhaRepository;
		}
	}
}