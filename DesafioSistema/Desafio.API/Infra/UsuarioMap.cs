using Desafio.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Desafio.API.Infra
{
    public class UsuarioMap : BaseMap<Usuario>
    {
        public UsuarioMap() : base("usuarios") { }

        public override void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).HasColumnName("id");
            builder.Property(u => u.Nome).HasColumnName("nome").HasMaxLength(150).IsRequired();
            builder.Property(u => u.CPF).HasColumnName("CPF").HasMaxLength(20).IsRequired();
            builder.HasIndex(u => u.CPF).IsUnique();
            builder.Property(u => u.Senha).HasColumnName("senha").HasMaxLength(250).IsRequired();
            builder.Property(u => u.Telefone).HasColumnName("telefone").HasMaxLength(15);

            //endereco
            builder.Property(u => u.Logradouro).HasColumnName("end_logradouro").HasMaxLength(150);
            builder.Property(u => u.Numero).HasColumnName("end_numero");
            builder.Property(u => u.Complemento).HasColumnName("end_complemento");
            builder.Property(u => u.Bairro).HasColumnName("end_bairro").HasMaxLength(150);
            builder.Property(u => u.Cidade).HasColumnName("end_cidade").HasMaxLength(150);
            builder.Property(u => u.Estado).HasColumnName("end_uf").HasMaxLength(2);

            base.Configure(builder);
        }

    }
}
