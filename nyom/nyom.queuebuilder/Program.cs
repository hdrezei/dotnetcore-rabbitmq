using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using nyom.domain.MongoDb.Message;
using nyom.infra.CrossCutting.Helper;
using nyom.infra.CrossCutting.Services;
using nyom.infra.Data.MongoDb.Repositories;
using nyom.infra.Data.MongoDb.Settings;

namespace nyom.queuebuilder
{
	public class Program
	{
        private static IServiceProvider _serviceProvider;

        public Program(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static IConfiguration Configuration { get; set; }

        private static void Main()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", false, true);
            Configuration = builder.Build();

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            _serviceProvider = serviceCollection.BuildServiceProvider();
            _serviceProvider.GetService<QueueBuilder>().Start();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.Configure<MongoDbSettings>(options =>
            {
                options.ConnectionString = Configuration.GetSection("MongoDbConnection:ConnectionString").Value;
                options.Database = Configuration.GetSection("MongoDbConnection:Database").Value;
            });

            services.AddOptions();
            services.AddSingleton(Configuration);
            services.AddScoped<IDockerHelper, DockerHelper>();
	        services.AddScoped<IEnfileirarMensagens, EnfileirarMensagens>();
			services.AddScoped<IMessageService, MessageService>();
	        services.AddScoped<IAtualizarStatus, AtualizarStatus>();
			services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddScoped<QueueBuilder>();
        }
    }
}