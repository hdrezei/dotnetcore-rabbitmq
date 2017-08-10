using System;
using nyom.infra.CrossCutting.Helper;

namespace nyom.workflow.manager
{
	public class ManagerFactory
	{
		public static void VerificarStatusCampanha(Guid id, Enum workflowStatus)
		{
			switch (workflowStatus)
			{
				case WorkflowStatus.Ready:
					ManagerServices.AtualizarStatusCampanha(id, WorkflowStatus.MessageBuilder);
					DockerHelper.CriarContainerDocker(id, "nyom.messagebuilder");
					break;

				case WorkflowStatus.MessageBuilder:
				case WorkflowStatus.QueueBuilder:
				case WorkflowStatus.PushSender:
					break;

				case WorkflowStatus.MessageBuilderCompleted:
					ManagerServices.AtualizarStatusCampanha(id, WorkflowStatus.QueueBuilder);
					DockerHelper.CriarContainerDocker(id, "nyom.queuebuilder");
					break;

				case WorkflowStatus.QueueBuilderCompleted:
					ManagerServices.AtualizarStatusCampanha(id, WorkflowStatus.PushSender);
					DockerHelper.CriarContainerDocker(id, "nyom.pushsender");
					break;
				case WorkflowStatus.PushSenderCompleted:
					ManagerServices.AtualizarStatusCampanha(id, WorkflowStatus.PushSender);
					DockerHelper.CriarContainerDocker(id, "nyom.mongo.logs");
					break;
				case WorkflowStatus.LoggingCleanup:
					ManagerServices.AtualizarStatusCampanha(id, WorkflowStatus.Finished);
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