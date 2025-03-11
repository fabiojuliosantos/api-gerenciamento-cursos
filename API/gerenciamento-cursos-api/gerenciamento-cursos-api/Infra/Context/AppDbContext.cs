using gerenciamento_cursos_api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace gerenciamento_cursos_api.Infra.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<Aluno> ? Alunos {  get; set; } // Criando tabela de Alunos que pode ser nula
    public DbSet<Curso> ? Cursos { get; set; }
    public DbSet<Matricula> ? Matriculas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder); 
    }
}
