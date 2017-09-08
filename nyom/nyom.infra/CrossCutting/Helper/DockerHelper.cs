using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Docker.DotNet;
using Docker.DotNet.Models;

namespace nyom.infra.CrossCutting.Helper
{
	public class DockerHelper : IDockerHelper
	{
		public async void RunAsync(Guid dadosCampanhaCampanhaId, string servico)
		{
			var client = new DockerClientConfiguration(new Uri("tcp://docker.for.win.localhost:2375"))
				.CreateClient();


			if (Environment.OSVersion.ToString().Contains("Windows"))
			{
				var argumento =
					string.Format(
						"docker run {0} --alias={1}  --network={2} --links={3}:{0} -e CAMPANHA={1} -v tcp://docker.for.win.localhost:2375:/var/run/docker.sock {0}",
						servico, dadosCampanhaCampanhaId, "dotnetcorerabbitmq_net.workflow", "mssql.workflow");
				Process.Start("cmd.exe", "/c " + argumento);
			}
			else
			{
				//var argumento =
				//	string.Format(
				//		"docker run {0} --alias={1}  --network={2} --links={3}:{0} -e CAMPANHA={1} -v tcp://docker.for.win.localhost:2375:/var/run/docker.sock {0}",
				//		servico, dadosCampanhaCampanhaId, "dotnetcorerabbitmq_net.workflow", "mssql.workflow");
				var parameters = new Config
				{
					Image = servico,
					ArgsEscaped = false,
					AttachStderr = false,
					AttachStdin = false,
					AttachStdout = true,
					Env = new[]
					{
						"CAMAPANHA="+dadosCampanhaCampanhaId.ToString()+""
					},
					
					Labels = new Dictionary<string, string>
						{  { "alias", dadosCampanhaCampanhaId.ToString() } },

					Cmd = new[]
					{
						//"--alias", dadosCampanhaCampanhaId.ToString(),
						//"--network", "dotnetcorerabbitmq_net.workflow",
						//"--links", "mssql.workflow:" + servico,
						//"-e", "CAMPANHA=" + dadosCampanhaCampanhaId,
						//"-v", "tcp://docker.for.win.localhost:2375:/var/run/docker.sock"
						string.Format(
							"--name={1} --alias={1}  --network={2} --links={3}:{0} -e CAMPANHA={1} -v tcp://docker.for.win.localhost:2375:/var/run/docker.sock {0}",
							servico, dadosCampanhaCampanhaId, "dotnetcorerabbitmq_net.workflow", "mssql.workflow")
					}
				};
				CreateContainerResponse response = await client.Containers.CreateContainerAsync(new CreateContainerParameters(parameters));

				Task task = client.Containers.StartContainerAsync(response.ID, new ContainerStartParameters());

				var config = new ContainerAttachParameters
				{
					Stream = true,
					Stderr = true,
					Stdin = false,
					Stdout = true,
					Logs = "1"
				};

				var buffer = new byte[1024];
				using (var stream = await client.Containers.AttachContainerAsync(response.ID, false, config, default(CancellationToken)))
				{
					var result = await stream.ReadOutputAsync(buffer, 0, buffer.Length, default(CancellationToken));
					do
					{
						Console.Write(Encoding.UTF8.GetString(buffer, 0, result.Count));
					}
					while (!result.EOF);
				}
			}
		}

		//docker run --name nyom.workflow.control --network=dotnetcorerabbitmq_net.workflow -links=mssql.workflow:nyom.workflow.control  nyom.workflow.control

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
			RunAsync(id, servico);
			Inspect(servico);
			Execute(servico);
		}
	}
}
