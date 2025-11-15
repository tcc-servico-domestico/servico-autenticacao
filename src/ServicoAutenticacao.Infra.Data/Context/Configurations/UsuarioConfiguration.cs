using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServicoAutenticacao.Domain.Entities;

namespace ServicoAutenticacao.Infra.Data.Context.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
       public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Email).IsRequired().HasMaxLength(150);
            builder.Property(s => s.Senha).IsRequired().HasMaxLength(150);
            builder.Property(s => s.Ativo).IsRequired();
            builder.Property(s => s.DataCriacao).HasDefaultValue(DateTime.Now);
            builder.Property(s => s.DataAtualizacao);
            builder.Property(s => s.DataUltimaAlteracaoSenha);
        }
    }
}


