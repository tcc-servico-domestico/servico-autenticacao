using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using ServicoAutenticacao.Application;
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
builder.Services.AddInfra(appSettings);
builder.Services.AddApplication();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var logger = services.GetRequiredService<ILogger<Program>>();

    try
    {
        var context = services.GetRequiredService<ServicoAutenticacaoDbContext>();

        var retries = 10;

        while (retries > 0)
        {
            try
            {
                await context.Database.MigrateAsync();
                break;
            }
            catch (Exception ex)
            {
                retries--;
                logger.LogError(ex, "Ocorreu um erro ao aplicar as migrations.");
                await Task.Delay(2000);
            }
        }
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "Ocorreu um erro ao aplicar as migrations.");
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseWelcomePage("/");

app.Run();

