using Microsoft.EntityFrameworkCore;
using ServicoDomestico.Autenticacao.Domain.Interfaces;
using ServicoDomestico.Autenticacao.Infrastructure.Data.Context;
using ServicoDomestico.Autenticacao.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(80);
});

// Banco de dados
builder.Services.AddDbContext<AutenticacaoDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Postgres")));

// Injeção de dependência
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

// Controllers
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Endpoints
app.MapGet("/", () => "API funcionando!");
app.MapGet("/ping-db", async (AutenticacaoDbContext db) =>
{
    var canConnect = await db.Database.CanConnectAsync();
    return canConnect ? "Conexão OK!" : "Falha na conexão";
});


app.MapControllers(); // Aqui está o uso que precisa do AddControllers()

app.Run();



