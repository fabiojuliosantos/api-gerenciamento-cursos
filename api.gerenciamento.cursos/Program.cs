using System.Data;
using api.gerenciamento.cursos.Infra.Context;
using FluentValidation;
using api.gerenciamento.cursos.Domain;
using api.gerenciamento.cursos.Dto;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using api.gerenciamento.cursos.Service.Interface;
using api.gerenciamento.cursos.Service.Services;
using api.gerenciamento.cursos.Infra.Interfaces;
using api.gerenciamento.cursos.Infra.Repositories;
using api.gerenciamento.cursos.Services.Interface;
using api.gerenciamento.cursos.Services.Services;


var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddScoped<IDbConnection>(provider =>
{
    SqlConnection connection = new SqlConnection(connectionString);
    connection.Open();
    return connection;
});


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString)); 

#region Services
builder.Services.AddScoped<ICursoService, CursoService>();
builder.Services.AddScoped<IAlunoService, AlunoService>(); 
builder.Services.AddScoped<IMatriculaService, MatriculaService>();
#endregion Services

#region Repositories
builder.Services.AddScoped<ICursoRepository, CursoRepository>();
builder.Services.AddScoped<IAlunoRepository, AlunoRepository>(); 
builder.Services.AddScoped<IMatriculaRepository, MatriculaRepository>();
#endregion Repositories

builder.Services.AddScoped<IValidator<Aluno>, AlunoEmailValidacao>();
builder.Services.AddScoped<IValidator<AlunoDto>, AlunoDtoValidacao>();
builder.Services.AddScoped<IValidator<AlunoAtualizacaoDto>, AlunoAtualizacaoDtoValidacao>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

