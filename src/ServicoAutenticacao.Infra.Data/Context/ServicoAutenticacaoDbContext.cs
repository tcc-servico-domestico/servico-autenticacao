using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Npgsql;
using ServicoAutenticacao.Domain.Entities;
using ServicoAutenticacao.Domain.Interfaces.Context;
using ServicoAutenticacao.Infra.CrossCutting.AppSettings;
using System.Data;

namespace ServicoAutenticacao.Infra.Data.Context
{
    public class ServicoAutenticacaoDbContext : DomainDbContext, IServicoAutenticacaoDbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }   

        public ServicoAutenticacaoDbContext(IOptions<AppSettings> appSettings)
        : base(ObterContextOptions(appSettings.Value))
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
            ChangeTracker.LazyLoadingEnabled = false;
        }

        private static DbContextOptions ObterContextOptions(AppSettings appSettings)
        {
            return new DbContextOptionsBuilder().UseNpgsql(appSettings?.ConnectionStrings?.ServicoAutenticacaoDB ?? string.Empty).Options;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ServicoAutenticacaoDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public override IDbConnection RetornaNovaConexao()
        {
            return new NpgsqlConnection(Database.GetDbConnection().ConnectionString);
        }

        public override IDbConnection RetornaNovaConexao(string connectionString)
        {

            return new NpgsqlConnection(Database.GetDbConnection().ConnectionString);
        }

        public override IDbConnection RetornaConexao()
        {
            return Database.GetDbConnection();
        }
    }
}
