using api.gerenciamento.cursos.Domain;
using Microsoft.EntityFrameworkCore;

namespace api.gerenciamento.cursos.Infra.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opts) : base(opts)
        {

        }
        public DbSet<Aluno>? Alunos { get; set; }
        public DbSet<Curso>? Cursos { get; set; }
        public DbSet<Matricula>? Matriculas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
