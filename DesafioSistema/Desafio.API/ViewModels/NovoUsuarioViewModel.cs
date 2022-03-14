namespace Desafio.API.ViewModels
{
    public class NovoUsuarioViewModel
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }
        public string Senha { get; set; }
        public string ConfirmarSenha { get; set; }
        public EnderecoViewModel? Endereco { get; set; }
    }
}
