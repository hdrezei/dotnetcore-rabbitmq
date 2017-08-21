using System;
using System.Linq;
using nyom.domain;
using nyom.domain.Crm.Campanha;
using nyom.domain.Crm.Empresa;
using nyom.domain.Crm.Pessoa;
using nyom.domain.Crm.Templates;
using nyom.infra.Data.EntityFramwork.Context;

namespace nyom.infra.Data.EntityFramwork.Initializers
{
	public class EntityFrameworkCrmInitializer
	{
		public static void Initialize(CrmContext context)
		{
			//context.Database.EnsureCreated();

			if (context.Campanhas.Any())
			{
				return;
			}

			Guid campanhaId = Guid.NewGuid();
			Guid workflowId = Guid.NewGuid();
			Guid templateId = Guid.NewGuid();
			Guid empresaId = Guid.NewGuid();
			Guid pessoaId =Guid.NewGuid();

			var campanha = new CampanhaCrm()
			{
				CampanhaId = campanhaId,
				DataCriacao = DateTime.Now,
				DataInicio = DateTime.Now,
				Nome = "Campanha de Teste",
				Publico = 100,
				Status = (int)WorkflowStatus.Ready,
				TemplateId = templateId
			};

			context.Campanhas.AddRange(campanha);

			if (context.Empresas.Any())
			{
				return;
			}

			var empresa = new Empresa()
			{
				EmpresaId = empresaId,
				CNPJ = "00000000000",
				Email = "teste@teste.com",
				Nome = "Teste",
				RazaoSocial = "Teste",
				Telefone = "01234567890"
			};

			context.Empresas.AddRange(empresa);

			if (context.Pessoas.Any())
			{
				return;
			}

			var pessoa = new Pessoa()
			{
				PessoaId = pessoaId,
				Bairro = "Teste",
				CampanhaId = campanhaId,
				CEP = "00000000",
				Cidade = "Teste",
				CPF = "00000000000",
				DataNascimento = DateTime.Now,
				Email = "teste@teste.com",
				Estado = "SP",
				Endereco = "Teste",
				Sobrenome = "teste",
				Nome="Teste"
			};

			context.Pessoas.AddRange(pessoa);

			if (context.Templates.Any())
			{
				return;
			}

			var template = new Template()
			{
				DataCriacao = DateTime.Now,
				Mensagem = "Mensagem de Teste",
				Nome = "Teste",
				Status = (int) WorkflowStatus.Ready,
				TemplateId = templateId
			};

			context.Templates.AddRange(template);
			context.SaveChanges();
		}
	}
}
