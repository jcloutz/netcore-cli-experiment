using AutoMapper;
using CLITaskRunner.Core.ApiClient.Resources;
using CLITaskRunner.Core.Models;

namespace CLITaskRunner.Core
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Resource to domain
            CreateMap<UserResource, User>();
            CreateMap<PostResource, Post>();
            CreateMap<TodoResource, Todo>();
            
        }
    }
}