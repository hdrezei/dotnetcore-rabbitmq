﻿using System;
using nyom.domain.core.EntityFramework.Models;

namespace nyom.domain.EntityFramework.Workflow.Campanha
{
	public class CampanhaWorkflowService : ServiceBase<CampanhaWorkflow> , ICampanhaWorkflowService
	{
		private readonly ICampanhaWorkflowRepository _campanhaRepository;
		public CampanhaWorkflowService(ICampanhaWorkflowRepository campanhaRepository) : base(campanhaRepository)
		{
			_campanhaRepository = campanhaRepository;
		}
		
		public void AtualizarStatusCampanha(Guid id, WorkflowStatus status)
		{
			var dadosCampanha = _campanhaRepository.Get(id);
			dadosCampanha.Status = (int) status;
			_campanhaRepository.Update(dadosCampanha);
		}
	}
}