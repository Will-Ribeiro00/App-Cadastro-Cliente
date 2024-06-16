using AppCliente_R.Entidades;
using Microsoft.EntityFrameworkCore;

namespace AppCliente_R.Repositorios.DataBase_Context
{
    public class ClienteDbContext : DbContext
    {
        public ClienteDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Clientes> CLIENTE { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clientes>()
                .Property(c => c.DATANASCIMENTO)
                .HasColumnType("DATE");
        }

    }
}

