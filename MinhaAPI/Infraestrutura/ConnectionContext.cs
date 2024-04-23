using Microsoft.EntityFrameworkCore;
using MinhaAPI.Model;


namespace MinhaAPI.Infraestrutura
{
    public class ConnectionContext : DbContext
    {

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Loja> Lojas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         => optionsBuilder.UseNpgsql(
             "Server=localhost;" +
             "Port=5432;Database=GestaoLojas;" +
             "User Id=postgres;" +
             "Password=12345;");

        public ConnectionContext()
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }
    }
}
