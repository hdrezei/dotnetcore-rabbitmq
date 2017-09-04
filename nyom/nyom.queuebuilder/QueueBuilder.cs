using System;
using nyom.domain;
using nyom.infra.CrossCutting.Services;

namespace nyom.queuebuilder
{
	public class QueueBuilder
	{
		private readonly IEnfileirarMensagens _enfileirarMensagens;
	    private readonly IAtualizarStatus _atualizarStatus;

		public QueueBuilder(IAtualizarStatus atualizarStatus, IEnfileirarMensagens enfileirarMensagens)
		{
			_atualizarStatus = atualizarStatus;
			_enfileirarMensagens = enfileirarMensagens;
		}

        public void Start()
        {
            Console.WriteLine(Environment.GetEnvironmentVariable("CAMPANHA"));
	        var enfileirar = _enfileirarMensagens.EnfileirarMensagensPush(Guid.Parse("4063DEBE-6EA0-4C54-B36E-2C65D0D6D060"));
	        _atualizarStatus.AtualizarStatusApi(Guid.Parse("4063DEBE-6EA0-4C54-B36E-2C65D0D6D060"), (int)WorkflowStatus.QueueBuilderCompleted);
		}
    }
}