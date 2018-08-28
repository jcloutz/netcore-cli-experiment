using System.Net.Http;

namespace CLITaskRunner.Core.ApiClient
{
    public interface IJsonPlaceholderApiClient
    {
        PostsClient Posts { get; }
    }

    public class JsonPlaceholderApiClient : IJsonPlaceholderApiClient
    {
        private readonly HttpClient _client;
        public PostsClient Posts { get; }

        public JsonPlaceholderApiClient(HttpClient client)
        {
            _client = client;
            Posts = new PostsClient(_client);
        }
    }
}