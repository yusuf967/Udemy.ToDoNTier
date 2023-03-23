using Microsoft.EntityFrameworkCore;
using Udemy.ToDoNTier.DataAccess.Configuration;
using Udemy.ToDoNTier.Entities.Domains;

namespace Udemy.ToDoNTier.DataAccess.Context
{
    public class TodoContext:DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options):base(options)
        {

        }
        public DbSet<Work> Works { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new WorkConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
