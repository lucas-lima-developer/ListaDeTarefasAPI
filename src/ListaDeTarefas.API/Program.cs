using ListaDeTarefas.Infrastructure;
using ListaDeTarefas.Domain.Extensions;

var builder = WebApplication.CreateBuilder(args);

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

AtualizarBaseDados();

app.Run();

void AtualizarBaseDados()
{
    var conexao = builder.Configuration.GetConexao();
    var nomeDatabase = builder.Configuration.GetNomeDatabase();

    Database.CriarDatabase(conexao, nomeDatabase);
}
