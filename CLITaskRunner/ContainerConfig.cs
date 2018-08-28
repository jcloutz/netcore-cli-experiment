using System.Net.Http;
using Autofac;
using CLITaskRunner.Core;
using CLITaskRunner.Core.ApiClient;
using CLITaskRunner.Core.Tasks;
using CLITaskRunner.Jobs;
using CLITaskRunner.Tasks;

namespace CLITaskRunner
{
    public static class ContainerConfig
    {
        public static ContainerBuilder RegisterCommon(this ContainerBuilder builder)
        {
            builder.RegisterType<HttpClient>()
                .AsSelf();

            builder.RegisterType<JsonPlaceholderApiClient>()
                .AsSelf()
                .As<IJsonPlaceholderApiClient>();

            return builder;
        } 
        
        public static ContainerBuilder RegisterJobs(this ContainerBuilder builder)
        {
            builder.RegisterType<SyncApiData>()
                .AsSelf()
                .As<IRunnable<SyncApiDataOptions>>();
            
            return builder;
        } 
        
        public static ContainerBuilder RegisterTasks(this ContainerBuilder builder)
        {
            builder.RegisterType<LoadPosts>()
                .As<IRunnable>()
                .Keyed<IRunnable>(TaskTypes.LoadPosts);
            
            return builder;
        } 
    }
}