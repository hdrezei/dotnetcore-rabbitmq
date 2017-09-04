using System;
using nyom.domain;
using nyom.infra.CrossCutting.Services;

namespace nyom.pushsender
{
	public class Sender
	{
		private readonly IAtualizarStatus _atualizarStatus;
		private readonly IEnviarMensagensPush _enviarMensagensPush;

		public Sender(IAtualizarStatus atualizarStatus, IEnviarMensagensPush enviarMensagensPush)
		{
			_atualizarStatus = atualizarStatus;
			_enviarMensagensPush = enviarMensagensPush;
		}

		public void Start()
		{
			PushMessages(Guid.Parse("4063DEBE-6EA0-4C54-B36E-2C65D0D6D060"));
		}
		public void PushMessages(Guid campanha)
		{
			var enviar = _enviarMensagensPush.Envia(campanha.ToString());

			if(enviar)
			_atualizarStatus.AtualizarStatusApi(campanha, (int) WorkflowStatus.PushSenderCompleted);
		}
	}
}

