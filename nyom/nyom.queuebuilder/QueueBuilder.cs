using System;
using nyom.domain.Message;
using nyom.domain.Workflow.Workflow;
using nyom.infra.CrossCutting.Helper;

namespace nyom.queuebuilder
{
	public class QueueBuilder
	{

		private readonly IMessageService _messageService;

		public QueueBuilder(IMessageService messageService)
		{
			_messageService = messageService;
		}

		public void EnfileirarMensagens(Guid id)
		{
			var mensagens = _messageService.FindAll(a => a.Status.Equals(WorkflowStatus.QueueBuilder));
			if (mensagens == null)
			{
				return;
			}
			
		}
	}
}