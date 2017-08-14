using System;
using nyom.domain.Crm.Pessoa;
using nyom.domain.Crm.Templates;
using nyom.domain.Message;
using nyom.domain.Workflow.Campanha;
using nyom.workflow.manager;

namespace nyom.messagebuilder
{
	public class Program
	{
		private static ITemplateService _templateservice;
		private static ICampanhaWorkflowService _campanhaWorkflowService;
		private static IPessoaService _pessoaService;
		private static IMessageService _messageService;
		private static IManagerServices _managerServices;

		public Program(IManagerServices managerServices, IMessageService messageService, IPessoaService pessoaService,
			ICampanhaWorkflowService campanhaWorkflowService, ITemplateService templateservice)
		{
			_managerServices = managerServices;
			_messageService = messageService;
			_pessoaService = pessoaService;
			_campanhaWorkflowService = campanhaWorkflowService;
			_templateservice = templateservice;
		}

		public static void Main(string[] args)
		{
			var mb = new MessageBuilder(_templateservice, _campanhaWorkflowService, _pessoaService, _messageService,
				_managerServices);
			var id = new Guid(args[0]);
			mb.MontarMensaagens(id);
		}
	}
}
