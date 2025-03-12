using api_gerenciamento_cursos.Infra.Context;
using api_gerenciamento_cursos.Infra.Interfaces;
using api_gerenciamento_cursos.Infra.Repositories;
using api_gerenciamento_cursos.Services.Interface;
using api_gerenciamento_cursos.Services.Service;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("FaculdadeConnection");

builder.Services.AddScoped<IDbConnection>(provider =>
{
    SqlConnection connection = new SqlConnection(connectionString);
    connection.Open();
    return connection;
});

builder.Services.AddScoped<IDbConnection>(provider =>
    new SqlConnection(connectionString)
);

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(connectionString));

#region Services
builder.Services.AddScoped<IAlunoService, AlunoService>();
builder.Services.AddScoped<ICursosService, CursosService>();
builder.Services.AddScoped<IMatriculaService, MatriculaService>();
#endregion

#region Repository
builder.Services.AddScoped<IAlunoRepository, AlunoRepository>();
builder.Services.AddScoped<ICursosRepository, CursosRepository>();
builder.Services.AddScoped<IMatriculaRepository, MatriculaRepository>();
#endregion

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
