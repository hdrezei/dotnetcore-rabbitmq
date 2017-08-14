using System;
using nyom.infra.CrossCutting.Helper;

namespace nyom.workflow.manager
{
	public class ManagerFactory : IManagerFactory
	{
		private readonly IManagerServices _managerServices;

		public ManagerFactory(IManagerServices managerServices)
		{
			_managerServices = managerServices;
		}

		public  void VerificarStatusCampanha(Guid id, Enum workflowStatus)
		{
			switch (workflowStatus)
			{
				case WorkflowStatus.Ready:
					_managerServices.AtualizarStatusCampanha(id, WorkflowStatus.MessageBuilder);
					DockerHelper.CriarContainerDocker(id, "nyom.messagebuilder");
					break;

				case WorkflowStatus.MessageBuilder:
				case WorkflowStatus.QueueBuilder:
				case WorkflowStatus.PushSender:
					break;

				case WorkflowStatus.MessageBuilderCompleted:
					_managerServices.AtualizarStatusCampanha(id, WorkflowStatus.QueueBuilder);
					DockerHelper.CriarContainerDocker(id, "nyom.queuebuilder");
					break;

				case WorkflowStatus.QueueBuilderCompleted:
					_managerServices.AtualizarStatusCampanha(id, WorkflowStatus.PushSender);
					DockerHelper.CriarContainerDocker(id, "nyom.pushsender");
					break;
				case WorkflowStatus.PushSenderCompleted:
					ManagerServices.AtualizarStatusCampanha(id, WorkflowStatus.LoggingCleanup);
					DockerHelper.CriarContainerDocker(id, "nyom.mongo.logs");
					break;
				case WorkflowStatus.LoggingCleanupCompleted:
					_managerServices.AtualizarStatusCampanha(id, WorkflowStatus.Finished);
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