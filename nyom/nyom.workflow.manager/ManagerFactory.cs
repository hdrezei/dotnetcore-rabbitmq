using System;
using nyom.infra.CrossCutting.Helper;

namespace nyom.workflow.manager
{
	public class ManagerFactory : IManagerFactory
	{
		private readonly IManagerServices _managerServices;
		private readonly IDockerHelper _dockerHelper;

		public ManagerFactory(IManagerServices managerServices, IDockerHelper dockerHelper)
		{
			_managerServices = managerServices;
			_dockerHelper = dockerHelper;
		}

		public void VerificarStatusCampanha(Guid id, Enum workflowStatus)
		{
			switch (workflowStatus)
			{
				case WorkflowStatus.Ready:
					_managerServices.AtualizarStatusCampanha(id, WorkflowStatus.MessageBuilder);
					_dockerHelper.CriarContainerDocker(id, "nyom.messagebuilder");
					break;

				case WorkflowStatus.MessageBuilder:
				case WorkflowStatus.QueueBuilder:
				case WorkflowStatus.PushSender:
					break;

				case WorkflowStatus.MessageBuilderCompleted:
					_managerServices.AtualizarStatusCampanha(id, WorkflowStatus.QueueBuilder);
					_dockerHelper.CriarContainerDocker(id, "nyom.queuebuilder");
					break;

				case WorkflowStatus.QueueBuilderCompleted:
					_managerServices.AtualizarStatusCampanha(id, WorkflowStatus.PushSender);
					_dockerHelper.CriarContainerDocker(id, "nyom.pushsender");
					break;
				case WorkflowStatus.PushSenderCompleted:
					_managerServices.AtualizarStatusCampanha(id, WorkflowStatus.LoggingCleanup);
					_dockerHelper.CriarContainerDocker(id, "nyom.mongo.logs");
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