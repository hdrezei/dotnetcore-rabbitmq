using System.Collections.Generic;
using nyom.domain.Crm.Campanha;
using nyom.domain.Crm.Pessoa;
using nyom.domain.Crm.Templates;

namespace nyom.messagebuilder
{
	public interface IMensagens
	{
		void MontarMensagens(string campanhaId);
		void SalvarMensagens(IEnumerable<Pessoa> listaPessoas, CampanhaCrm dadosCampanha, Template dadosTemplate);
	}
}