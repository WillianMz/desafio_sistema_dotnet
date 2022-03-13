using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Base.Entidades
{
    public class UsuarioEndereco
    {
        protected UsuarioEndereco() { }

        public UsuarioEndereco(Usuario usuario, string logradouro, int numero, string complemento, 
                               string bairro, string cidade, string estado)
        {
            Usuario = usuario;
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
        }

        public int UsuarioId { get; private set; }
        public virtual Usuario? Usuario { get; private set; }
        public string? Logradouro { get; private set; }
        public int Numero { get; private set; }
        public string? Complemento { get; private set; }
        public string? Bairro { get; private set; }
        public string? Cidade { get; private set; }
        public string? Estado { get; private set; }
    }
}
