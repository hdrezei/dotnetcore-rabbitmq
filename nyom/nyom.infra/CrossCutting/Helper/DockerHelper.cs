using System;
using System.Diagnostics;

namespace nyom.infra.CrossCutting.Helper
{
	public class DockerHelper : IDockerHelper
	{
		public void Run(Guid dadosCampanhaCampanhaId, string servico)
		{
			var argumento =
				string.Format(
					"docker run {0} --alias={1}  --net {2} --links {3} -e CAMPANHA={1} -v tcp://docker.for.win.localhost:2375:/var/run/docker.sock",
					servico, dadosCampanhaCampanhaId, "net.workflow", "mssql.workflow");
			Process.Start("cmd.exe", "/c " + argumento);
		}

		public void Inspect(string servico)
		{
			var argumento = string.Format("docker inspect {0}", servico);
			Process.Start("cmd.exe", "/c " + argumento);
		}

		public void Execute(string servico)
		{
			var argumento = string.Format("docker exec -d {0}", servico);
			Process.Start("cmd.exe", "/c " + argumento);
		}

		public void CriarContainerDocker(Guid id, string servico)
		{
			Run(id, servico);
			Inspect(servico);
			Execute(servico);
		}
	}
}
