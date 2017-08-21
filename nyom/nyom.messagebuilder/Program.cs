using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using nyom.domain.core.EntityFramework.Interfaces;
using nyom.domain.core.EntityFramework.Models;
using nyom.domain.Crm.Campanha;
using nyom.domain.Crm.Pessoa;
using nyom.domain.Crm.Templates;
using nyom.domain.Message;
using nyom.infra;
using nyom.infra.CrossCutting.Helper;
using nyom.infra.Data.EntityFramwork.Context;
using nyom.infra.Data.EntityFramwork.Repositories.Crm;
using nyom.infra.Data.MongoDb.Repositories;
using nyom.infra.Data.MongoDb.Settings;
using nyom.workflow.manager.Factory;
using nyom.workflow.manager.Interfaces;

namespace nyom.messagebuilder
{
    public class Program
    {
        private static IServiceProvider _serviceProvider;
        private static object _context;

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

            var serviceProvider = serviceCollection.BuildServiceProvider();

            serviceProvider.GetService<Builder>().MontarMensagens(Environment.GetEnvironmentVariable("CAMPANHA"));
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();

            services.AddSingleton<IConfiguration>(Configuration);
           

            services.AddScoped<ITemplateService, TemplateService>();
            services.AddScoped<ITemplateRepository, TemplateRepository>();
            services.AddScoped<IPessoaService, PessoaService>();
            services.AddScoped<IPessoaRepository, PessoaRepository>();
            services.AddScoped<ICampanhaCrmService, CampanhaCrmService>();
            services.AddScoped<ICampanhaCrmRepository, CampanhaCrmRepository>();
            services.AddScoped<IManagerFactory, ManagerFactory>();
            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<IDockerHelper, DockerHelper>();
            services.AddScoped(typeof(IRepositoryBase<>),
                typeof(infra.Data.EntityFramwork.Repositories.RepositoryBase<>));
            services.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<>));

            services.AddScoped(typeof(domain.core.MongoDb.Repository.Interface.IRepositoryBase<>),
                typeof(infra.Data.MongoDb.Repositories.RepositoryBase<>));
            services.AddScoped(typeof(domain.core.MongoDb.Repository.Interface.IServiceBase<>),
                typeof(domain.core.MongoDb.Repository.Models.ServiceBase<>));

            services.AddScoped<Builder>();
            services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddTransient<IDbContext, CrmContext>();
            //services.AddScoped(typeof(IOptions<>));
            services.Configure<MongoDbSettings>(options => Configuration.GetSection("MongoDbSettings").Bind(options));
            services.Configure<IOptions<MongoDbSettings>>(
                o => new MessageRepository(o));
        }


    }
    
}