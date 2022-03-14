using Desafio.API.Models;

namespace Desafio.API.Interfaces
{
    public interface IUsuarioRep
    {
        Task Create(Usuario model);
        Task Update(Usuario model);
        Task Delete(Usuario model);
        Task<Usuario> GetById(int id);
        Task<IEnumerable<Usuario>> GetAll();
        Task Save();
        Task<bool> GetCPF(string cpf);
    }
}
