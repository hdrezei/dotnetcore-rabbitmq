using System;
using System.Diagnostics;

namespace nyom.infra.CrossCutting.Helper
{
    public class DockerHelper : IDockerHelper
    {
        public void Run(Guid dadosCampanhaCampanhaId, string servico)
        {
    //        using (var processo = new Process())
    //        {
    //            processo.StartInfo.FileName = Environment.GetEnvironmentVariable("comspec");
    //            processo.StartInfo.Arguments = string.Format(@"docker run {0} --alias={1}  --net {2} --links{3} -e CAMPANHA={1} -v tcp://docker.for.win.localhost:2375:/var/run/docker.sock", servico, dadosCampanhaCampanhaId, "dotnetcorerabbitmq_net.workflow", "mssql.workflow");
				//Console.WriteLine(string.Format(@"docker run {0} --alias={1}  --net {2} --links {3} -e CAMPANHA={1} -v tcp://docker.for.win.localhost:2375:/var/run/docker.sock", servico, dadosCampanhaCampanhaId, "dotnetcorerabbitmq_net.workflow", "mssql.workflow"));
				//processo.StartInfo.RedirectStandardOutput = true;
    //            processo.StartInfo.UseShellExecute = false;
    //            processo.StartInfo.CreateNoWindow = true;
	   //         System.Diagnostics.Process.Start("CMD.exe", processo.StartInfo.Arguments);
    //            //processo.Start();
    //        }

	
			var argumento = string.Format("docker run {0} --alias={1}  --net {2} --links {3} -e CAMPANHA={1} -v tcp://docker.for.win.localhost:2375:/var/run/docker.sock", servico, dadosCampanhaCampanhaId, "net.workflow", "mssql.workflow");
	        System.Diagnostics.Process.Start("cmd.exe", "/c "+argumento);
	       

        }

        public void Inspect(string servico)
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

        public void Execute(string servico)
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

        public void CriarContainerDocker(Guid id, string servico)
        {
            Run(id, servico);
            Inspect(servico);
            Execute(servico);
        }
    }
}
