using Desafio.API.Models;
using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;

namespace Desafio.API.Infra
{
    public class DesafioContext : DbContext
    {
        public DesafioContext(DbContextOptions options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Notification>();
            modelBuilder.ApplyConfiguration(new UsuarioMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
