using Example.TodoWebApp.Data.Configurations;
using Example.TodoWebApp.Data.Domains;
using Microsoft.EntityFrameworkCore;

namespace Example.TodoWebApp.Data.Context
{
    public class TodoContext : DbContext
    {
        public DbSet<Work> Works { get; set; }
        public TodoContext(
                DbContextOptions<TodoContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new WorkConfiguration());
        }
    }
}
