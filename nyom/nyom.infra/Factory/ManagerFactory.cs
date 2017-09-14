using System;
using nyom.domain;
using nyom.domain.EntityFramework.Workflow.Campanha;
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

		public void VerificarStatusCampanha()
		{
			Console.WriteLine(Environment.GetEnvironmentVariable("CAMPANHA"));
			var id = Guid.Parse(Environment.GetEnvironmentVariable("CAMPANHA"));
			var dadosCampanha = _campanhaWorkflowService.Find(a => a.CampanhaId.Equals(id));
			var workflowStatus = dadosCampanha.Status;

			switch (workflowStatus)
			{
				case (int)WorkflowStatus.WorkflowManager:
					
					_atualizarStatus.AtualizarStatusApi(id,(int)WorkflowStatus.MessageBuilder);
					_dockerHelper.RunAsync(id, "nyom.messagebuilder");
					Console.WriteLine("Status Atualizado, iniciando MessageBuilder");
					break;

				case (int)WorkflowStatus.MessageBuilder:
				case (int)WorkflowStatus.QueueBuilder:
				case (int)WorkflowStatus.PushSender:
                case (int)WorkflowStatus.LoggingCleanup:
					break;

				case (int)WorkflowStatus.MessageBuilderCompleted:
					Console.WriteLine("Entrou aqui 2");
					_atualizarStatus.AtualizarStatusApi(id, (int)WorkflowStatus.QueueBuilder);
					_dockerHelper.RunAsync(id, "nyom.queuebuilder");
					Console.WriteLine("Status Atualizado, iniciando QueuBuilder");
					break;

				case (int)WorkflowStatus.QueueBuilderCompleted:
					_atualizarStatus.AtualizarStatusApi(id, (int)WorkflowStatus.PushSender);
					_dockerHelper.RunAsync(id, "nyom.pushsender");
					Console.WriteLine("Status Atualizado, iniciando PushSender");
					break;

				case (int)WorkflowStatus.PushSenderCompleted:
					_atualizarStatus.AtualizarStatusApi(id, (int)WorkflowStatus.Finished);
					Console.WriteLine("Status Atualizado, Finalizado");
					break;

				case (int)WorkflowStatus.LoggingCleanupCompleted:
					_atualizarStatus.AtualizarStatusApi(id, (int)WorkflowStatus.Finished);
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