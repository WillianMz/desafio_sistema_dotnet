namespace Desafio.API.ViewModels
{
    public class UsuarioViewModel
    {
        public int? Id { get; set; }
        public string? Nome { get; set; }
        public string? CPF { get; set; }
        public string? Telefone { get; set; }
        //public EnderecoViewModel? Endereco { get; set; }
        public string? Logradouro { get; set; }
        public int? Numero { get; set; }
        public string? Complemento { get; set; }
        public string? Bairro { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
    }
}
