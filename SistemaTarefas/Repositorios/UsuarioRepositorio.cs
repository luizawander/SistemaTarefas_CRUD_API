using Microsoft.EntityFrameworkCore;
using SistemaTarefas.Data;
using SistemaTarefas.Models;
using SistemaTarefas.Repositorios.Interfaces;

namespace SistemaTarefas.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly SistemasDeTarefasDBContext _dbContext;
        public UsuarioRepositorio(SistemasDeTarefasDBContext sistemasDeTarefasDBContext)
        {
            _dbContext = sistemasDeTarefasDBContext;
        }

        public async Task<UsuarioModel> adicionar(UsuarioModel usuario) //ok
        {
            await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();

            return usuario;

        }

        public async Task<bool> Apagar(int id) //ok
        {
            UsuarioModel usuarioPorId = await BuscarPorID(id);

            if (usuarioPorId == null)
            {
                throw new Exception($"Usuário não encontrado para o ID: {usuarioPorId}");
            }

            _dbContext.Usuarios.Remove(usuarioPorId);
            await _dbContext.SaveChangesAsync();
            return true;

        }

        public async Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id) //ok
        {
            UsuarioModel usuarioPorId = await BuscarPorID(id);
            
            if (usuarioPorId == null) 
            {  
                throw new Exception($"Usuário não encontrado para o ID: {usuarioPorId}"); 
            }

            usuarioPorId.Name = usuario.Name;   
            usuario.Email = usuario.Email;

            _dbContext.Usuarios.Update(usuarioPorId);
            await _dbContext.SaveChangesAsync();

            return usuarioPorId;
        }

        public async Task<UsuarioModel> BuscarPorID(int id) //ok
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<UsuarioModel>> BuscarTodosUsuarios() //ok
        {
            return await _dbContext.Usuarios.ToListAsync();
        }
    }
}

