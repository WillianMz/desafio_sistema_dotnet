using Desafio.API.Infra;
using Desafio.API.Interfaces;
using Desafio.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Desafio.API.Infra
{
    public class UsuarioRepositorio : IUsuarioRep
    {
        private readonly DesafioContext _context;

        public UsuarioRepositorio(DesafioContext context)
        {
            _context = context;
        }

        public async Task<bool> GetCPF(string cpf)
        {
            try
            {
                return await _context.Usuarios.AnyAsync(u => u.CPF == cpf);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task Create(Usuario model)
        {
            try
            {
                _context.Usuarios.Add(model);
                await Save();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task Update(Usuario model)
        {
            try
            {
                _context.Usuarios?.Update(model);
                await Save();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task Delete(Usuario model)
        {
            try
            {
                _context.Usuarios?.Remove(model);
                await Save();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Usuario> GetById(int id)
        {
            try
            {
                return await _context.Usuarios.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Usuario>> GetAll()
        {
            try
            {
                return await _context.Usuarios.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task Save()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
