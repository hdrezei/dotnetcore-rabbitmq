using System;
using nyom.domain.Workflow.Campanha;
using nyom.infra.CrossCutting.Helper;
using nyom.workflow.manager.Interfaces;

namespace nyom.workflow.manager.Factory
{
	public class ManagerFactory : IManagerFactory
	{
		private readonly IManagerServices _managerServices;
		private readonly IDockerHelper _dockerHelper;
		private readonly ICampanhaWorkflowService _campanhaWorkflowService;

		public ManagerFactory(IManagerServices managerServices, IDockerHelper dockerHelper, ICampanhaWorkflowService campanhaWorkflowService)
		{
			_managerServices = managerServices;
			_dockerHelper = dockerHelper;
			_campanhaWorkflowService = campanhaWorkflowService;
		}

		public void VerificarStatusCampanha(string id)
		{
			var Id = new Guid(id);
			var dadosCampanha = _campanhaWorkflowService.Find(a => a.CampanhaId.Equals(Id));
			var workflowStatus = dadosCampanha.Status;

			switch (workflowStatus)
			{
				case WorkflowStatus.WorkflowManager:
					_managerServices.AtualizarStatusCampanha(Id, WorkflowStatus.MessageBuilder);
					_dockerHelper.CriarContainerDocker(Id, "nyom.messagebuilder");
					break;

				case WorkflowStatus.MessageBuilder:
				case WorkflowStatus.QueueBuilder:
				case WorkflowStatus.PushSender:
					break;

				case WorkflowStatus.MessageBuilderCompleted:
					_managerServices.AtualizarStatusCampanha(Id, WorkflowStatus.QueueBuilder);
					_dockerHelper.CriarContainerDocker(Id, "nyom.queuebuilder");
					break;

				case WorkflowStatus.QueueBuilderCompleted:
					_managerServices.AtualizarStatusCampanha(Id, WorkflowStatus.PushSender);
					_dockerHelper.CriarContainerDocker(Id, "nyom.pushsender");
					break;
				case WorkflowStatus.PushSenderCompleted:
					_managerServices.AtualizarStatusCampanha(Id, WorkflowStatus.LoggingCleanup);
					_dockerHelper.CriarContainerDocker(Id, "nyom.mongo.logs");
					break;
				case WorkflowStatus.LoggingCleanupCompleted:
					_managerServices.AtualizarStatusCampanha(Id, WorkflowStatus.Finished);
					break;
				case WorkflowStatus.Finished:
					break;
				case WorkflowStatus.Error:
					break;
				default:
					throw new ArgumentOutOfRangeException(nameof(workflowStatus), workflowStatus, null);
			}
		}

		
	}
}