using Desafio.API.Util;
using Flunt.Validations;

namespace Desafio.API.Models
{
    public class Usuario : BaseModel
    {
        protected Usuario() { }

        public Usuario(string nome, string cpf, string senha, string telefone)
        {
            Nome = nome.Trim().ToUpper();
            CPF = cpf;
            Senha = GerarMD5.CalculaHash(senha);
            Telefone = telefone;
            CadastradoEm = DateTime.UtcNow;

            AddNotifications(new Contract<Usuario>()
                .Requires()
                .IsNotNullOrEmpty(nome, "Nome", "Nome do usuário é obrigatório!")
                .IsNotNullOrEmpty(cpf, "CPF", "CPF é obrigatório")
                .IsNotNullOrEmpty(senha, "Senha", "Informe a senha!"));
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string CPF { get; private set; }
        public string Senha { get; set; }
        public string Telefone { get; private set; }

        //endereco
        public string? Logradouro { get; private set; }
        public int Numero { get; private set; }
        public string? Complemento { get; private set; }
        public string? Bairro { get; private set; }
        public string? Cidade { get; private set; }
        public string? Estado { get; private set; }


        public void Editar(string nome, string telefone)
        {
            Nome = nome.Trim().ToUpper();
            Telefone = telefone.Trim();

            AddNotifications(new Contract<Usuario>()
                .Requires()
                .IsNotNullOrEmpty(nome, "Nome", "Nome do usuário é obrigatório!"));
        }

        public void AtualizarEndereco(Endereco endereco)
        {
            Logradouro = endereco.Logradouro;
            Numero = endereco.Numero;
            Complemento = endereco.Complemento;
            Bairro = endereco.Bairro;
            Cidade = endereco.Cidade;
            Estado = endereco.Estado;
        }

    }
}
