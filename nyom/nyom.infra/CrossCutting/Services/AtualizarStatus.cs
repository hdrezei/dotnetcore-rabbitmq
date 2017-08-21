using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace nyom.infra.CrossCutting.Services
{
    public class AtualizarStatus : IAtualizarStatus
    {
	    public async Task AtualizarStatusApi(Guid dadosCampanhaCampanhaId, int status)
	    {
			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri("http://localhost:5000/");
				client.DefaultRequestHeaders.Accept.Clear();
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				var response = await client.GetAsync("api/campanha?id=" + dadosCampanhaCampanhaId + "&status=" + status);
				Console.WriteLine(response.IsSuccessStatusCode ? "Status alterado com sucesso" : "Erro na alteração do Status");
				Console.ReadKey();
			}
		}
    }
}
