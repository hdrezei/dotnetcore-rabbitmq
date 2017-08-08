using nyom.domain.Crm.Templates;
using System;

namespace nyom.messagebuilder
{
	public class MessageBuilder
	{
		private readonly ITemplateService _templateservice;

		public MessageBuilder(ITemplateService templateservice)
		{
			_templateservice = templateservice;
		}

		public void MontarMensaagens(Guid campanhaId, Guid templateId, int publico)
		{
			//var dadosTemplate = _templateservice.Get(templateId);
		}
	}
}