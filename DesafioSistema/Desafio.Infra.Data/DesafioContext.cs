using Desafio.Base.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Infra.Data
{
    public class DesafioContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
