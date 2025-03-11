using GerenciamentoCurso.Domain;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoCurso.Infra.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<Alunos> ? Alunos { get; set; }
    public DbSet<Cursos> ? Cursos { get; set; }
    public DbSet<Matricula> ? Matriculas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
