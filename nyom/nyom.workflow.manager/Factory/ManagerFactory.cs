using System;
using nyom.domain;
using nyom.domain.Workflow.Campanha;
using nyom.infra.CrossCutting.Helper;
using nyom.workflow.manager.Interfaces;

namespace nyom.workflow.manager.Factory
{
	public class ManagerFactory : IManagerFactory
	{
		
		private readonly IDockerHelper _dockerHelper;
		private readonly ICampanhaWorkflowService _campanhaWorkflowService;

		public ManagerFactory( IDockerHelper dockerHelper, ICampanhaWorkflowService campanhaWorkflowService)
		{
			
			_dockerHelper = dockerHelper;
			_campanhaWorkflowService = campanhaWorkflowService;
		}

		public void VerificarStatusCampanha(string id)
		{
			//var Id = new Guid(id);
			var Id = new Guid("4063debe-6ea0-4c54-b36e-2c65d0d6d060");
			var dadosCampanha = _campanhaWorkflowService.Find(a => a.CampanhaId.Equals(Id));
			var workflowStatus = dadosCampanha.Status;

			switch (workflowStatus)
			{
				case 1:
					_campanhaWorkflowService.AtualizarStatusCampanha(Id, WorkflowStatus.MessageBuilder);
					_dockerHelper.CriarContainerDocker(Id, "nyom.messagebuilder");
					break;

				case 3:
				case 5:
				case 7:
					break;

				case 4:
					_campanhaWorkflowService.AtualizarStatusCampanha(Id, WorkflowStatus.QueueBuilder);
					_dockerHelper.CriarContainerDocker(Id, "nyom.queuebuilder");
					break;

				case 6:
					_campanhaWorkflowService.AtualizarStatusCampanha(Id, WorkflowStatus.PushSender);
					_dockerHelper.CriarContainerDocker(Id, "nyom.pushsender");
					break;
				case 8:
					_campanhaWorkflowService.AtualizarStatusCampanha(Id, WorkflowStatus.LoggingCleanup);
					_dockerHelper.CriarContainerDocker(Id, "nyom.mongo.logs");
					break;
				case 10:
					_campanhaWorkflowService.AtualizarStatusCampanha(Id, WorkflowStatus.Finished);
					break;
				case 11:
					break;
				case 12:
					break;
				default:
					throw new ArgumentOutOfRangeException(nameof(workflowStatus), workflowStatus, null);
			}
		}

		
	}
}