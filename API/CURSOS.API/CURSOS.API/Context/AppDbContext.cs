using CURSOS.API.Domain;
using Microsoft.EntityFrameworkCore;

namespace CURSOS.API.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Alunos> ? Alunos { get; set; }
    public DbSet<Cursos> ? Cursos { get; set; }
    public DbSet<Matricula> ? Matricula { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
