using Microsoft.EntityFrameworkCore;

namespace MinimalApi.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=app.db;Cache=Shared");
    }
}
