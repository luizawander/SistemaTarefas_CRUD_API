using Microsoft.EntityFrameworkCore;
using SistemaTarefas.Data;
using SistemaTarefas.Models;

namespace SistemaTarefas.Data
{
    public class SistemasDeTarefasDBContext : DbContext
    {
        public SistemasDeTarefasDBContext(DbContextOptions<SistemasDeTarefasDBContext> options) : base (options)
        {         
        } //ORM facilita trabalho com banco de dados. 

        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<TarefaModel> Tarefa { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
