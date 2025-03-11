using System.Data;
using gerenciamento_cursos_api.Infra.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Configuração da string de conexão
string connectionString = builder.Configuration.GetConnectionString("DefaultCOnnection");


builder.Services.AddScoped<IDbConnection>(provider => // Provedor abrindo a conexão
{
    // Estância do banco
    SqlConnection connection = new(connectionString);
    connection.Open();
    return connection; // Retornando a conexão criada
});

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(connectionString));

#region Injeção de dependências

#region Services

#endregion

#endregion

#region AutoMapper
builder.Services.AddAutoMapper(typeof(Program));
#endregion

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
