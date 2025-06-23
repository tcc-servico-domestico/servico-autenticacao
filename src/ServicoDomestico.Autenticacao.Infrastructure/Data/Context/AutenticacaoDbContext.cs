using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ServicoDomestico.Autenticacao.Domain.Interfaces.Context;
using ServicoDomestico.Autenticacao.Domain.Interfaces.Utils;
using ServicoDomestico.Autenticacao.Domain.Models;
using ServicoDomestico.Autenticacao.Domain.Models.LogAcesso;
using ServicoDomestico.Autenticacao.Domain.Models.Permissao;
using ServicoDomestico.Autenticacao.Domain.Models.Pessoa;
using ServicoDomestico.Autenticacao.Domain.Models.Possui;
using ServicoDomestico.Autenticacao.Domain.Models.Telefone;
using ServicoDomestico.Autenticacao.Domain.Models.Token;
using ServicoDomestico.Autenticacao.Domain.Models.TrabalhadorDomestico;
using ServicoDomestico.Autenticacao.Domain.Models.Usuario;
using System.Data;

namespace ServicoDomestico.Autenticacao.Infrastructure.Data.Context
{
    public class AutenticacaoDbContext : DomainDbContext, IAutenticacaoDbContext
    {
        public AutenticacaoDbContext(DbContextOptions<AutenticacaoDbContext> options) : base(options) { }

        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Telefone> Telefones { get; set; }
        public DbSet<TrabalhadorDomestico> TrabalhadoresDomesticos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Permissao> Permissoes { get; set; }
        public DbSet<Possui> Possui { get; set; }
        public DbSet<LogAcesso> LogsAcesso { get; set; }
        public DbSet<Token> Tokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AutenticacaoDbContext).Assembly);

            base.OnModelCreating(modelBuilder);

            // Pessoa - Telefone (1:N)
            modelBuilder.Entity<Pessoa>()
                .HasMany(p => p.Telefones)
                .WithOne(t => t.Pessoa)
                .HasForeignKey(t => t.PessoaId)
                .OnDelete(DeleteBehavior.Cascade);

            // Pessoa - TrabalhadorDomestico (1:1)
            modelBuilder.Entity<Pessoa>()
                .HasOne(p => p.TrabalhadorDomestico)
                .WithOne(t => t.Pessoa)
                .HasForeignKey<TrabalhadorDomestico>(t => t.PessoaId)
                .OnDelete(DeleteBehavior.Cascade);

            // Pessoa - Usuario (1:1)
            modelBuilder.Entity<Pessoa>()
                .HasOne(p => p.Usuario)
                .WithOne(u => u.Pessoa)
                .HasForeignKey<Usuario>(u => u.PessoaId)
                .OnDelete(DeleteBehavior.Cascade);

            // Usuario - Possui (N:N) via Possui
            modelBuilder.Entity<Possui>()
                .HasKey(p => new { p.UsuarioId, p.PermissaoId });

            modelBuilder.Entity<Possui>()
                .HasOne(p => p.Permissao)
                .WithMany(per => per.Usuarios)
                .HasForeignKey(p => p.PermissaoId)
                .OnDelete(DeleteBehavior.Restrict);



            // Configure propriedades padrão para datas
            modelBuilder.Entity<Pessoa>()
                .Property(p => p.DataCriacao)
                .HasDefaultValueSql("NOW()");

            modelBuilder.Entity<Pessoa>()
                .Property(p => p.DataAtualizacao)
                .HasDefaultValueSql("NOW()");

            modelBuilder.Entity<TrabalhadorDomestico>()
                .Property(t => t.DataCriacao)
                .HasDefaultValueSql("NOW()");

            modelBuilder.Entity<TrabalhadorDomestico>()
                .Property(t => t.DataAtualizacao)
                .HasDefaultValueSql("NOW()");

            modelBuilder.Entity<Usuario>()
                .Property(u => u.DataCriacao)
                .HasDefaultValueSql("NOW()");

            modelBuilder.Entity<LogAcesso>()
                .Property(l => l.DataLogin)
                .HasDefaultValueSql("NOW()");

            modelBuilder.Entity<Token>()
                .Property(t => t.DataCriacao)
                .HasDefaultValueSql("NOW()");
        }


        /// <summary>
        /// Retorna uma nova conexão independente.
        /// Essa conexão deve receber dispose
        /// </summary>
        /// <returns>Uma instância da implementação de IDbConnection</returns>
        public override IDbConnection RetornaNovaConexao()
        {
            return new SqlConnection(Database.GetConnectionString());
        }

        public override IDbConnection RetornaNovaConexao(string stringDeConexao)
        {
            return new SqlConnection(stringDeConexao);
        }

        /// <summary>
        /// Essa conexão é a conexão do EF
        /// Essa conexão não deve receber dispose
        /// </summary>
        /// <returns>Uma instância da implementação de IDbConnection</returns>
        public override IDbConnection RetornaConexao()
        {
            return Database.GetDbConnection();
        }
    }
}
