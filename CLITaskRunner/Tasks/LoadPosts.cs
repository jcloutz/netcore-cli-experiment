using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CLITaskRunner.Core;
using CLITaskRunner.Core.ApiClient;
using CLITaskRunner.Core.ApiClient.Resources;
using CLITaskRunner.Core.Models;
using Microsoft.Extensions.Logging;

namespace CLITaskRunner.Tasks
{
    public class LoadPosts : IRunnable
    {
        private readonly IJsonPlaceholderApiClient _client;
        private readonly MasterDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<LoadPosts> _logger;

        public LoadPosts(IJsonPlaceholderApiClient client, MasterDbContext context, IMapper mapper, ILogger<LoadPosts> logger)
        {
            _client = client;
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }


        public async Task<int> Run()
        {
            var response = await _client.Posts.GetAll();

            var posts = _mapper.Map<IList<PostResource>, IList<Post>>(response);

            await _context.Posts.AddRangeAsync(posts);
            await _context.SaveChangesAsync();

            return _context.Posts.Count();
        }
    }
}