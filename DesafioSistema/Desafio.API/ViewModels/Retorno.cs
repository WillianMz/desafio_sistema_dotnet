namespace Desafio.API.ViewModels
{
    public class Retorno
    {
        public Retorno(bool sucesso, string mensagem)
        {
            Sucesso = sucesso;
            Mensagem = mensagem;
        }

        public Retorno(bool sucesso, string mensagem, object dados)
        {
            Sucesso = sucesso;
            Mensagem = mensagem;
            Dados = dados;
        }

        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
        public object Dados { get; set; }
    }
}
