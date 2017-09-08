using System;
using nyom.domain;
using nyom.domain.EntityFramework.Workflow.Campanha;
using nyom.domain.Workflow.Campanha;
using nyom.infra.CrossCutting.Helper;
using nyom.infra.CrossCutting.Services;

namespace nyom.infra.Factory
{
	public class ManagerFactory : IManagerFactory
	{
		private readonly IDockerHelper _dockerHelper;
		private readonly ICampanhaWorkflowService _campanhaWorkflowService;
		private readonly IAtualizarStatus _atualizarStatus;

		public ManagerFactory( IDockerHelper dockerHelper, ICampanhaWorkflowService campanhaWorkflowService, IAtualizarStatus atualizarStatus)
		{
			_dockerHelper = dockerHelper;
			_campanhaWorkflowService = campanhaWorkflowService;
			_atualizarStatus = atualizarStatus;
		}

		public void VerificarStatusCampanha(object state)
		{
			//var Id = new Guid(Enviroment);
			//var id = new Guid(Environment.GetEnvironmentVariable("CAMPANHA"));
			var Id = new Guid("4063DEBE-6EA0-4C54-B36E-2C65D0D6D060");
			var dadosCampanha = _campanhaWorkflowService.Find(a => a.CampanhaId.Equals(Id));
			var workflowStatus = dadosCampanha.Status;

			switch (workflowStatus)
			{
				case (int)WorkflowStatus.WorkflowManager:
					_atualizarStatus.AtualizarStatusApi(Id,(int)WorkflowStatus.MessageBuilder);
					_dockerHelper.CriarContainerDocker(Id, "nyom.messagebuilder");
					Console.WriteLine("Status Atualizado, iniciando MessageBuilder");
					break;

				case (int)WorkflowStatus.MessageBuilder:
				case (int)WorkflowStatus.QueueBuilder:
				case (int)WorkflowStatus.PushSender:
                case (int)WorkflowStatus.LoggingCleanup:
					break;

				case (int)WorkflowStatus.MessageBuilderCompleted:
					_atualizarStatus.AtualizarStatusApi(Id, (int)WorkflowStatus.QueueBuilder);
					_dockerHelper.CriarContainerDocker(Id, "nyom.queuebuilder");
					Console.WriteLine("Status Atualizado, iniciando QueuBuilder");
					break;

				case (int)WorkflowStatus.QueueBuilderCompleted:
					_atualizarStatus.AtualizarStatusApi(Id, (int)WorkflowStatus.PushSender);
					_dockerHelper.CriarContainerDocker(Id, "nyom.pushsender");
					Console.WriteLine("Status Atualizado, iniciando PushSender");
					break;

				case (int)WorkflowStatus.PushSenderCompleted:
					_atualizarStatus.AtualizarStatusApi(Id, (int)WorkflowStatus.Finished);
					Console.WriteLine("Status Atualizado, Finalizado");
					break;

				case (int)WorkflowStatus.LoggingCleanupCompleted:
					_atualizarStatus.AtualizarStatusApi(Id, (int)WorkflowStatus.Finished);
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