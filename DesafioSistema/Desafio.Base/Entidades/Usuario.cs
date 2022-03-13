using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Base.Entidades
{
    public class Usuario
    {
        private readonly List<UsuarioEndereco>? _enderecos;

        protected Usuario() { }

        public Usuario(string nome, string cpf, string telefone)
        {
            _enderecos = new();
            Nome = nome;
            CPF = cpf;
            Telefone = telefone;
        }

        public int Id { get; private set; }
        public string? Nome { get; private set; }
        public string? CPF { get; private set; }
        public string? Telefone { get; private set; }        

        //relacionamento
        public virtual IReadOnlyCollection<UsuarioEndereco>? Enderecos => _enderecos;

        public void Editar(string nome, string telefone)
        {
            Nome = nome.Trim().ToUpper();
            Telefone = telefone.Trim();
        }

        public void AdicionarEndereco(UsuarioEndereco endereco)
        {
            _enderecos?.Add(endereco);
        }

    }
}
