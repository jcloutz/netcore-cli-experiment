using System.Threading.Tasks;
using CLITaskRunner.Core;
using CLITaskRunner.Core.ApiClient;
using Microsoft.Extensions.Logging;

namespace CLITaskRunner.Jobs
{
    public class SyncApiData : IRunnable<SyncApiDataOptions>
    {
        private readonly IJsonPlaceholderApiClient _apiClient;
        private readonly ILogger<SyncApiData> _logger;

        public PostsClient PostsClient { get; set; }

        public SyncApiData(IJsonPlaceholderApiClient apiClient, ILogger<SyncApiData> logger)
        {
            _apiClient = apiClient;
            _logger = logger;
        }
        
        public async Task<int> Run(SyncApiDataOptions opts)
        {
            _logger.LogInformation("Running Job 1");
            var posts = await _apiClient.Posts.Get(q => q);
            _logger.LogInformation($"Loaded {posts.Count} posts");
            _logger.LogInformation("Finished Job 1");

            return posts.Count;
        }
    }
}