using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using ServicoAutenticacao.Infra.CrossCutting.AppSettings;
using ServicoAutenticacao.Infra.Data.Context;
using ServicoAutenticacao.Infra.IoC;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<AppSettings>(builder.Configuration);
var appSettings = builder.Configuration.Get<AppSettings>() ?? new AppSettings();

builder.Services
    .AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ContractResolver =
            new CamelCasePropertyNamesContractResolver();
    });

builder.Services.AddSwaggerGen();
builder.Services.ResolveDependencias(appSettings);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        try
        {
            var context = services.GetRequiredService<ServicoAutenticacaoDbContext>();
            await context.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            var logger = services.GetRequiredService<ILogger<Program>>();
            logger.LogError(ex, "Ocorreu um erro ao aplicar as migrations.");
        }
    }
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseWelcomePage("/");

app.Run();
