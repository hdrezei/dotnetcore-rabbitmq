using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using nyom.domain.Workflow.Campanha;
using nyom.infra.CrossCutting.Helper;

namespace nyom.api.Controllers
{
	[Route("api/[controller]")]
	public class MessageBuilderController : Controller
	{
		private readonly ICampanhaWorkflowService _campanhaWorkflowService;

		public MessageBuilderController(ICampanhaWorkflowService campanhaWorkflowService)
		{
			_campanhaWorkflowService = campanhaWorkflowService;
		}


		[HttpPost]
	    public HttpStatusCode AtualizarCampanha([FromBody]string value)
		{
			try
			{
				var dadosCampanha = _campanhaWorkflowService.Find(a => a.CampanhaId.Equals(value));
				dadosCampanha.Status = WorkflowStatus.MessageBuilderCompleted;
				_campanhaWorkflowService.Update(dadosCampanha);

				return  HttpStatusCode.OK;
			}
			catch (Exception)
			{
				return HttpStatusCode.BadRequest;
			}
			
		}
	}
}
