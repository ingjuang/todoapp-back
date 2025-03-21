using Microsoft.EntityFrameworkCore;
using TodoApp_Back.Domain.Entities;

namespace TodoApp_Back.Infraestructure.DBContext
{
    public class SQLServerContext : DbContext
    {
        public SQLServerContext(DbContextOptions<SQLServerContext> options) : base(options)
        {
        }

        public DbSet<Domain.Entities.TaskEntity> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.Entities.TaskEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<Domain.Entities.TaskEntity>().Property(x => x.Name).IsRequired();
            modelBuilder.Entity<Domain.Entities.TaskEntity>().Property(x => x.IsCompleted).IsRequired();
        }

    }
}
