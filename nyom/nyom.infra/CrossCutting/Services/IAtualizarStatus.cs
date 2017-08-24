using System;

namespace nyom.infra.CrossCutting.Services
{
	public interface IAtualizarStatus
	{
		 void AtualizarStatusApi(Guid dadosCampanhaCampanhaId, int status);
	}
}