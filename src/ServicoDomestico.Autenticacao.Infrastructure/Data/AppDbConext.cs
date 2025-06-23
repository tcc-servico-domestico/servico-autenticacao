using Microsoft.EntityFrameworkCore;
using ServicoDomestico.Autenticacao.Domain.Models;

namespace ServicoDomestico.Autenticacao.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

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
                .HasOne(p => p.Usuario)
                .WithMany(u => u.Permissoes)
                .HasForeignKey(p => p.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);

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
    }
}
