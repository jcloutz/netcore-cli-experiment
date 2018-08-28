using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CLITaskRunner.Core.ApiClient.Resources;
using Newtonsoft.Json;

namespace CLITaskRunner.Core.ApiClient
{
    public class PostsClient
    {
        private readonly HttpClient _client;

        public PostsClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<IList<PostResource>> GetAll()
        {
            var uri = $"{ApiClientBaseConfig.BASE_URL}/posts";

            var response = await GetRequest(uri);
            
            return response;
        }

        public async Task<IList<PostResource>> Get(Func<IQueryParamBuilder, IQueryParamBuilder> queryParams)
        {
            var builder = new QueryParamBuilder();

            var queryString = queryParams(builder).Build();
            var uri = $"{ApiClientBaseConfig.BASE_URL}/posts{queryString}";

            var response = await GetRequest(uri);
            return response;
        }

        private async Task<IList<PostResource>> GetRequest(string uri)
        {
            var response = await _client.GetAsync(uri);
            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<PostResource>>(json);
        }
    }
}