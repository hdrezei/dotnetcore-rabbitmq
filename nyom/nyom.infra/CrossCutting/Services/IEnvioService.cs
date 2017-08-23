namespace nyom.infra.CrossCutting.Services
{
	public interface IEnvioService
	{
		void SalvarResultadoEnvio(string campanha, string message);
	}
}