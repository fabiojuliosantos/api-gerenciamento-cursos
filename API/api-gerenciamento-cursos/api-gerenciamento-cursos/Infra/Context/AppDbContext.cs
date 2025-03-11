using api_gerenciamento_cursos.Domain;
using Microsoft.EntityFrameworkCore;

namespace api_gerenciamento_cursos.Infra.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opts) : base(opts)
        {

        }
        public DbSet<Aluno>? Alunos { get; set; }
        public DbSet<Cursos>? Cursos { get; set; }
        public DbSet<Matriculas>? Matriculas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
