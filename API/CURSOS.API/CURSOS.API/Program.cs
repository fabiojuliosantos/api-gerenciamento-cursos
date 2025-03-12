using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using CURSOS.API.Context;
using CURSOS.API.Infra.Interfaces;
using CURSOS.API.Infra.Repositories;
using CURSOS.API.Application.Services;
using CURSOS.API.Application.Interfaces;

var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddScoped<IDbConnection>(provider =>
{
    SqlConnection connection = new SqlConnection(connectionString);
    connection.Open();
    return connection;
});

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(connectionString));

#region Repositories
builder.Services.AddScoped<IAlunosRepository, AlunosRepository>();
builder.Services.AddScoped<ICursosRepository, CursosRepository>();
builder.Services.AddScoped<IMatriculaRepository, MatriculaRepository>();
#endregion

#region Services
builder.Services.AddScoped<IAlunosServices, AlunosServices>();
builder.Services.AddScoped<ICursosServices, CursosServices>();
builder.Services.AddScoped<IMatriculaServices, MatriculaServices>();
#endregion

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
