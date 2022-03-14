using Desafio.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Desafio.API.Infra
{
    public class BaseMap<TModel> : IEntityTypeConfiguration<TModel> where TModel : BaseModel
    {
        private readonly string _table;

        public BaseMap(string tableName = "")
        {
            _table = tableName;
        }

        public virtual void Configure(EntityTypeBuilder<TModel> builder)
        {
            if(!string.IsNullOrEmpty(_table))
                builder.ToTable(_table);

            builder.Property(x => x.CadastradoEm).HasColumnName("dt_cadastro");
        }
    }
}
