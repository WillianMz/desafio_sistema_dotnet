using Desafio.API.Models;
using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;

namespace Desafio.API.Infra
{
    public class DesafioContext : DbContext
    {
        public DesafioContext(DbContextOptions options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        //public DbSet<UsuarioEndereco> Enderecos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Notification>();
            //modelBuilder.Ignore<UsuarioEndereco>();
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            //modelBuilder.ApplyConfiguration(new UsuarioEnderecoMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
