using Flunt.Validations;

namespace Desafio.API.Models
{
    public class Endereco : BaseModel
    {
        public Endereco(string logradouro, int numero, string complemento, string bairro, 
                        string cidade, string estado)
        {
            Logradouro = logradouro.Trim().ToUpper();
            Numero = numero;
            Complemento = complemento.Trim().ToUpper();
            Bairro = bairro.Trim().ToUpper();
            Cidade = cidade.Trim().ToUpper();
            Estado = estado.Trim().ToUpper();

            AddNotifications(new Contract<Endereco>()
                .Requires()
                .IsNotNullOrEmpty(logradouro,"Logradouro","Informe o logradouro")
                .IsNotNullOrEmpty(bairro,"Bairro","Informe o bairro")
                .IsNotNullOrEmpty(cidade,"Cidade","Informe a cidade")
                .IsNotNullOrEmpty(estado,"UF","Infome o estado-UF"));
        }

        public string? Logradouro { get; private set; }
        public int Numero { get; private set; }
        public string? Complemento { get; private set; }
        public string? Bairro { get; private set; }
        public string? Cidade { get; private set; }
        public string? Estado { get; private set; }
    }
}
