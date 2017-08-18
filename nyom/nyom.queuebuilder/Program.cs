using System;
using Microsoft.Extensions.Configuration;
using nyom.domain.Message;

namespace nyom.queuebuilder
{
	public class Program
	{

		private static IMessageService _messageService;

		public Program(IMessageService messageService)
		{
			_messageService = messageService;
		}

		private static void Main(string[] args)
		{
			var qb = new QueueBuilder(_messageService);
			var id = new Guid(args[0]);
			qb.EnfileirarMensagens(id);
		}		
	}
}