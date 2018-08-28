using System;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using CLITaskRunner.Core;
using CLITaskRunner.Core.ApiClient;
using CLITaskRunner.Jobs;
using CommandLine;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CLITaskRunner
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var serviceProvider = ConfigureContainer();
            
            var job = serviceProvider.GetService<IRunnable<SyncApiDataOptions>>();
            await Parser.Default.ParseArguments<SyncApiDataOptions>(args)
                .MapResult(
                    (SyncApiDataOptions opts) => job.Run(opts),
                    errs => Task.FromResult(0)
                );
        }

        static AutofacServiceProvider ConfigureContainer()
        {
            // configure service collection 
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton(new LoggerFactory()
                .AddConsole()
                .AddDebug());
            
            serviceCollection.AddLogging();
            serviceCollection.AddAutoMapper();
            serviceCollection.AddDbContext<MasterDbContext>(opt => 
                opt.UseInMemoryDatabase(Guid.NewGuid().ToString())
            );

            // configure autofac container
            var containerBuilder = new ContainerBuilder();
            containerBuilder.Populate(serviceCollection);
            
            // build autofac container
            var container = containerBuilder
                .RegisterCommon()
                .RegisterJobs()
                .Build();
            
            // Build service provider
            return new AutofacServiceProvider(container);
        }
    }
}