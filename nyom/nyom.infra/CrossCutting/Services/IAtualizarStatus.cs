using System;
using System.Threading.Tasks;

namespace nyom.infra.CrossCutting.Services
{
	public interface IAtualizarStatus
	{
		Task AtualizarStatusApi(Guid dadosCampanhaCampanhaId, int status);
	}
}