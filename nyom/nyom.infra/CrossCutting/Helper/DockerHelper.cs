using System;
using System.Diagnostics;
using nyom.domain.Workflow.Campanha;

namespace nyom.infra.CrossCutting.Helper
{
	public static class DockerHelper
	{
		public static void Run(Guid dadosCampanhaCampanhaId)
		{
			using (var processo = new Process())
			{
				processo.StartInfo.FileName = Environment.GetEnvironmentVariable("comspec");
				processo.StartInfo.Arguments = string.Format("{0}:{1} {2}", "docker run nyom.workflowmanager",dadosCampanhaCampanhaId.ToString(), " --net net.workflow");
				processo.StartInfo.RedirectStandardOutput = true;
				processo.StartInfo.UseShellExecute = false;
				processo.StartInfo.CreateNoWindow = true;
				processo.Start();
			}
		}

		public static void Inspect()
		{
			using (var processo = new Process())
			{
				processo.StartInfo.FileName = Environment.GetEnvironmentVariable("comspec");
				processo.StartInfo.Arguments = string.Format("{0}", "docker inspect nyom.workflowmanager");
				processo.StartInfo.RedirectStandardOutput = true;
				processo.StartInfo.UseShellExecute = false;
				processo.StartInfo.CreateNoWindow = true;
				processo.Start();
			}
		}

		public static void Execute()
		{
			using (var processo = new Process())
			{
				processo.StartInfo.FileName = Environment.GetEnvironmentVariable("comspec");
				processo.StartInfo.Arguments = string.Format("{0}", "docker exec nyom.workflowmanager");
				processo.StartInfo.RedirectStandardOutput = true;
				processo.StartInfo.UseShellExecute = false;
				processo.StartInfo.CreateNoWindow = true;
				processo.Start();
			}
		}
	}
}
