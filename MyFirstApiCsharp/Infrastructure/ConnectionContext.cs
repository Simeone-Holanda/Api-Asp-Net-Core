using Microsoft.EntityFrameworkCore;
using MyFirstApiCsharp.Model;

namespace MyFirstApiCsharp.Infrastructure
{
    public class ConnectionContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql(
                "Server=localhost;" +
                "Port=5432;Database=AspNetFirstApi;" +
                "User id=postgres;" +
                "Password=Inn_04H/a.pkw[*(;"
            );
        }
    }
}
