using Microsoft.EntityFrameworkCore;
using SistemaTarefas.Data;
using SistemaTarefas.Models;
using SistemaTarefas.Repositorios.Interfaces;

namespace SistemaTarefas.Repositorios
{
    public class TarefaRepositorio : ITarefaRepositorio
    {
        private readonly SistemasDeTarefasDBContext _dbContext;
        public TarefaRepositorio(SistemasDeTarefasDBContext sistemasDeTarefasDBContext)
        {
            _dbContext = sistemasDeTarefasDBContext;
        }

        public async Task<TarefaModel> adicionar(TarefaModel tarefa) //ok
        {
            await _dbContext.Tarefa.AddAsync(tarefa);
            await _dbContext.SaveChangesAsync();

            return tarefa;

        }

        public async Task<bool> Apagar(int id) //ok
        {
            TarefaModel tarefaPorId = await BuscarPorID(id);

            if (tarefaPorId == null)
            {
                throw new Exception($"Tarefa não encontrada para o ID: {id}");
            }

            _dbContext.Tarefa.Remove(tarefaPorId);
            await _dbContext.SaveChangesAsync();
            return true;
             
        }

        public async Task<TarefaModel> Atualizar(TarefaModel tarefa, int id) //ok
        {
            TarefaModel tarefaPorId = await BuscarPorID(id);
            
            if (tarefaPorId == null) 
            {  
                throw new Exception($"Tarefa não encontrada para o ID: {id}"); 
            }

            tarefaPorId.Nome = tarefa.Nome;
            tarefa.Descricao = tarefa.Descricao;
            tarefaPorId.Status = tarefa.Status;
            tarefaPorId.UsuarioID = tarefa.UsuarioID;

            _dbContext.Tarefa.Update(tarefaPorId);
            await _dbContext.SaveChangesAsync();

            return tarefaPorId;
        }

        public async Task<TarefaModel> BuscarPorID(int id) //ok
        {
            return await _dbContext.Tarefa.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<TarefaModel>> BuscarTodasTarefas() //ok
        {
            return await _dbContext.Tarefa.ToListAsync();
        }
    }
}

