using CLITaskRunner.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace CLITaskRunner.Core
{
    public class MasterDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Todo> Todos { get; set; }
        
        public MasterDbContext(DbContextOptions<MasterDbContext> options)
            : base(options) { }
    }
}