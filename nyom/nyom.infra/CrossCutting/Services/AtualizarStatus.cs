using System;
using System.Net.Http;

namespace nyom.infra.CrossCutting.Services
{
	public class AtualizarStatus : IAtualizarStatus
    {
	    public  void AtualizarStatusApi(Guid dadosCampanhaCampanhaId, int status)
	    {
			using (var client = new HttpClient())
			{
				var response = client.GetAsync("http://localhost:52031/api/campanha?id=" + dadosCampanhaCampanhaId + "&status=" + status).Result;

				if (!response.IsSuccessStatusCode) return;
				var responseContent = response.Content;
				var responseString = responseContent.ReadAsStringAsync().Result;
			}
	    }
    }
}
