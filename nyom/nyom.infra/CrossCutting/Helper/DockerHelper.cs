using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
				var parameters = new Config
				{
					Image = servico,
					ArgsEscaped = true,
					AttachStderr = true,
					AttachStdin = false,
					AttachStdout = true,
					OpenStdin = false,
					StdinOnce = false,
					Env = new[]
					{
						"CAMPANHA=" + dadosCampanhaCampanhaId + ""
					},
					Labels = new Dictionary<string, string>
					{
						{"Links", "mssql.workflow:nyom.workflow.manager"}
					},
					Cmd = new[]
					{
						string.Format(
							"--name {0} --net={1} -links={2}:{0}",
							servico, "dotnetcorerabbitmq_net.workflow", "mssql.workflow"),
						"bash"
					}
				};

				var net = new NetworkingConfig
				{
					EndpointsConfig = new Dictionary<string, EndpointSettings>
					{
						{
							"dotnetcorerabbitmq_net.workflow", new EndpointSettings
							{
								Links = new List<string>
								{
									"mssql.workflow:nyom.workflow.manager"
								}
							}
						}
					}
				};

				var response =
					await client.Containers.CreateContainerAsync(
						new CreateContainerParameters(parameters) {Name = servico, NetworkingConfig = net});
				Task task = client.Containers.StartContainerAsync(response.ID, new ContainerStartParameters());
				var config = new ContainerAttachParameters
				{
					Stream = true,
					Stderr = false,
					Stdin = true,
					Stdout = true
				};

				var buffer = new byte[1024];
				using (var stream =
					await client.Containers.AttachContainerAsync(response.ID, false, config, default(CancellationToken)))
				{
					using (var fileStream = File.Create($"{DateTime.Now.Ticks}.jpg"))
					{
						await stream.CopyOutputToAsync(null, fileStream, null, default(CancellationToken));
					}
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