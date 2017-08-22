using System;
using nyom.domain.Results;

namespace nyom.infra.CrossCutting.Services
{
	public class EnvioService : IEnvioService
	{
		private readonly IResultsServices _resultsServices;

		public EnvioService(IResultsServices resultsServices)
		{
			_resultsServices = resultsServices;
		}

		public void SalvarResultadoEnvio(string campanha, string message)
		{
			var results = new Results()
			{
				Id = Guid.Parse(campanha),
				Mensagem = message
			};
			_resultsServices.SaveOneAsync(results);
		}
	}
}