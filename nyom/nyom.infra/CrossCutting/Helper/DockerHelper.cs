using System;
using System.Diagnostics;

namespace nyom.infra.CrossCutting.Helper
{
	public  class DockerHelper : IDockerHelper
	{
		public  void Run(Guid dadosCampanhaCampanhaId,string servico)
		{
			using (var processo = new Process())
			{
				processo.StartInfo.FileName = Environment.GetEnvironmentVariable("comspec");
				processo.StartInfo.Arguments = string.Format("docker run {0} --alias={1}  --net {2} --links {3} -e CAMPANHA={1}" , servico, dadosCampanhaCampanhaId, "net.workflow", "mssql.workflow");
				processo.StartInfo.RedirectStandardOutput = true;
				processo.StartInfo.UseShellExecute = false;
				processo.StartInfo.CreateNoWindow = true;
				processo.Start();
			}
		}

		public  void Inspect(string servico)
		{
			using (var processo = new Process())
			{
				processo.StartInfo.FileName = Environment.GetEnvironmentVariable("comspec");
				processo.StartInfo.Arguments = string.Format("docker inspect {0}", servico);
				processo.StartInfo.RedirectStandardOutput = true;
				processo.StartInfo.UseShellExecute = false;
				processo.StartInfo.CreateNoWindow = true;
				processo.Start();
			}
		}

		public  void Execute(string servico)
		{
			using (var processo = new Process())
			{
				processo.StartInfo.FileName = Environment.GetEnvironmentVariable("comspec");
				processo.StartInfo.Arguments = string.Format("docker exec -d {0}", servico);
				processo.StartInfo.RedirectStandardOutput = true;
				processo.StartInfo.UseShellExecute = false;
				processo.StartInfo.CreateNoWindow = true;
				processo.Start();
			}
		}

		public  void  CriarContainerDocker(Guid id, string servico)
		{
			Run(id,servico);
			Inspect(servico);
			Execute(servico);
		}		
	}
}
