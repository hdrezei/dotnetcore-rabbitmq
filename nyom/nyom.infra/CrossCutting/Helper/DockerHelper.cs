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
					"docker run {0} --alias={1}  --net {2} --links {3}:{0} -e CAMPANHA={1} -v tcp://docker.for.win.localhost:2375:/var/run/docker.sock",
					servico, dadosCampanhaCampanhaId, "net.workflow", "mssql.workflow");

			using (var processo = new Process())
			{
				processo.StartInfo.FileName = Environment.GetEnvironmentVariable("comspec");
				processo.StartInfo.Arguments = string.Format("docker run {0} --alias={1}  --net {2} --links {3}:{0} -e CAMPANHA={1} -v tcp://docker.for.win.localhost:2375:/var/run/docker.sock",
					servico, dadosCampanhaCampanhaId, "net.workflow", "mssql.workflow");
				processo.StartInfo.RedirectStandardOutput = true;
				processo.StartInfo.UseShellExecute = false;
				processo.StartInfo.CreateNoWindow = true;
				processo.Start();
			}
			//Process process = new System.Diagnostics.Process();
			//Process proc = new System.Diagnostics.Process();
			//proc.StartInfo.FileName(@"C:\Windows\System32\cmd.exe");
			//proc.Start(argumento);

			//ProcessStartInfo psi = new ProcessStartInfo();
			//psi.WindowStyle = ProcessWindowStyle.Normal;
			//psi.FileName = @"C:\Program Files\Git\bin\bash.exe";
			//psi.WorkingDirectory = @"C:\Program Files\Docker Toolbox";
			//psi.Arguments = @"--login -i ""C:\Program Files\Docker Toolbox\start.sh""  docker-machine inspect default";
			//psi.UseShellExecute = false;
			//psi.RedirectStandardOutput = true;

			//Process process = Process.Start(psi);

			Console.WriteLine(argumento);

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
