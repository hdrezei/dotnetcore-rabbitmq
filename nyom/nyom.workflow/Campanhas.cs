using nyom.domain.Workflow.Campanha;
using nyom.messagebuilder;

namespace nyom.workflow
{
	public class Campanhas
	{

		private readonly ICampanhaService _campanhaService;

		public Campanhas(ICampanhaService campanhaService)
		{
			_campanhaService = campanhaService;
		}

		public void BuscaCampanha()
		{
			var dadosCampanha = _campanhaService.Find(a => a.Status.Equals(Status.Pronto));

			var messageBuilder = new MessageBuilder();

			messageBuilder.MontarMensaagens(dadosCampanha.CampanhaId, dadosCampanha.TemplateId, dadosCampanha.Publico);

		}
	}
}
