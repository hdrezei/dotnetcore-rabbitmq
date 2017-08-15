using System;
using nyom.domain.Message;
using nyom.infra.CrossCutting.Helper;

namespace nyom.workflow.manager
{

	

	public class TesteEscrita
	{
		private readonly IMessageService _messageService;

		public TesteEscrita(IMessageService messageService)
		{
			_messageService = messageService;
		}


		public void TesteEscritaMongo()
		{
			for (int i = 0; i <= 1000; i++)
			{
				Message message = new Message()
				{
					CampanhaId = i.ToString(),
					DataEntregaMensagens = DateTime.Now,
					DataCriacao = DateTime.Now,
					Id = i.ToString(),
					Mensagem = "teste",
					Status = WorkflowStatus.Finished,
					TemplateId = i.ToString()
				};
				_messageService.SaveOneAsync(message);
			}
			
		}


	}
}