using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace nyom.infra.CrossCutting.Helper
{
	public class DockerHelper : IDockerHelper
	{
		public void Run(Guid dadosCampanhaCampanhaId, string servico)
		{
			var comando = string.Format(
				"docker run {0} --alias={1}  --net {2} --links {3}:{0} -e CAMPANHA={1} -v tcp://docker.for.win.localhost:2375:/var/run/docker.sock {0}",
				servico, dadosCampanhaCampanhaId, "net.worflow", "mssql.workflow");

			var escapedArgs = comando.Replace("\"", "\\\"");
			var process = new Process()
			{
				StartInfo = new ProcessStartInfo
				{
					FileName = "/bin/bash",
					Arguments = $"-c \"{escapedArgs}\"",
					RedirectStandardOutput = true,
					UseShellExecute = false,
					CreateNoWindow = true,
				}
			};
			process.Start();
		}
	
		public void Inspect(string servico)
		{
			var argumento = string.Format("docker inspect {0}", servico);
			var escapedArgs = argumento.Replace("\"", "\\\"");
			var process = new Process()
			{
				StartInfo = new ProcessStartInfo
				{
					FileName = "/bin/bash",
					Arguments = $"-c \"{escapedArgs}\"",
					RedirectStandardOutput = true,
					UseShellExecute = false,
					CreateNoWindow = true,
				}
			};
			process.Start();
			process.StandardOutput.ReadToEnd();
			process.WaitForExit();
		}

		public void Execute(string servico)
		{
			var argumento = string.Format("docker exec -d {0}", servico);
			var escapedArgs = argumento.Replace("\"", "\\\"");
			var process = new Process()
			{
				StartInfo = new ProcessStartInfo
				{
					FileName = "/bin/bash",
					Arguments = $"\"{escapedArgs}\"",
					RedirectStandardOutput = true,
					UseShellExecute = false,
					CreateNoWindow = true,
				}
			};
			process.Start();
			process.StandardOutput.ReadToEnd();
			process.WaitForExit();
		}

		public void CriarContainerDocker(Guid id, string servico)
		{
			Run(id, servico);
			Inspect(servico);
			Execute(servico);
		}
	}
}
