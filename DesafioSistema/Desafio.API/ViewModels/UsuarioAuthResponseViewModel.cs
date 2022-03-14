namespace Desafio.API.ViewModels
{
    public class UsuarioAuthResponseViewModel
    {
        public UsuarioAuthResponseViewModel(UsuarioViewModel usuario, string token)
        {
            Usuario = usuario;
            Token = token;
        }

        public UsuarioViewModel Usuario { get; set; }
        public string Token { get; set; }
    }
}
