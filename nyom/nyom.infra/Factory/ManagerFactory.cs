using System;
using nyom.domain;
using nyom.domain.Workflow.Campanha;
using nyom.infra.CrossCutting.Helper;

namespace nyom.infra.Factory
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
			var Id = new Guid("4063DEBE-6EA0-4C54-B36E-2C65D0D6D060");
			var dadosCampanha = _campanhaWorkflowService.Find(a => a.CampanhaId.Equals(Id));
			var workflowStatus = dadosCampanha.Status;

			switch (workflowStatus)
			{
				case (int)WorkflowStatus.WorkflowManager:
					_campanhaWorkflowService.AtualizarStatusCampanha(Id, WorkflowStatus.MessageBuilder);
					_dockerHelper.CriarContainerDocker(Id, "nyom.messagebuilder");
					break;

				case (int)WorkflowStatus.MessageBuilder:
				case (int)WorkflowStatus.QueueBuilder:
				case (int)WorkflowStatus.PushSender:
                case (int)WorkflowStatus.LoggingCleanup:
					break;

				case (int)WorkflowStatus.MessageBuilderCompleted:
					_campanhaWorkflowService.AtualizarStatusCampanha(Id, WorkflowStatus.QueueBuilder);
					_dockerHelper.CriarContainerDocker(Id, "nyom.queuebuilder");
					break;

				case (int)WorkflowStatus.QueueBuilderCompleted:
					_campanhaWorkflowService.AtualizarStatusCampanha(Id, WorkflowStatus.PushSender);
					_dockerHelper.CriarContainerDocker(Id, "nyom.pushsender");
					break;

				case (int)WorkflowStatus.PushSenderCompleted:
					_campanhaWorkflowService.AtualizarStatusCampanha(Id, WorkflowStatus.LoggingCleanup);
					_dockerHelper.CriarContainerDocker(Id, "nyom.mongo.logs");
					break;

				case (int)WorkflowStatus.LoggingCleanupCompleted:
					_campanhaWorkflowService.AtualizarStatusCampanha(Id, WorkflowStatus.Finished);
					break;

				case (int)WorkflowStatus.Finished:
					break;

				case (int)WorkflowStatus.Error:
					break;

                case (int)WorkflowStatus.Blocked:
                    break;

                case (int)WorkflowStatus.Cancelled:
                    break;
                default:
					throw new ArgumentOutOfRangeException(nameof(workflowStatus), workflowStatus, null);
			}
		}
	}
}