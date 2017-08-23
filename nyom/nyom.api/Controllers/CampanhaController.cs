using System;
using Microsoft.AspNetCore.Mvc;
using nyom.domain.Workflow.Campanha;

namespace nyom.api.Controllers
{
	[Route("api/[controller]")]
	public class CampanhaController : Controller
	{
		private readonly ICampanhaWorkflowService _campanhaWorkflowService;

		public CampanhaController(ICampanhaWorkflowService campanhaWorkflowService)
		{
			_campanhaWorkflowService = campanhaWorkflowService;
		}

		[HttpPost]
		public IActionResult AtualizarCampanha(string id, int status)
		{
			var campanhaId = Guid.Parse(id);
			try
			{
				var dadosCampanha = _campanhaWorkflowService.Find(a => a.CampanhaId.Equals(campanhaId));
				dadosCampanha.Status = status;
				_campanhaWorkflowService.Update(dadosCampanha);

				return new ObjectResult(true);
			}
			catch (Exception)
			{
				return new ObjectResult(false);
			}
		}
	}
}
