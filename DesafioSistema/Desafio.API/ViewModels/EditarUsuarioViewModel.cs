namespace Desafio.API.ViewModels
{
    public class EditarUsuarioViewModel
    {
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public EnderecoViewModel? Endereco { get; set; }
    }
}
