using MatrizDeRastreabilidade.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MatrizDeRastreabilidade.API.Data.Configurations
{
    public class ProjetoConfiguration : IEntityTypeConfiguration<Projeto>
    {
        public void Configure(EntityTypeBuilder<Projeto> builder)
        {
            builder.ToTable("Projeto");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Nome)
                .HasColumnType("varchar(50)");
            builder.Property(p => p.Apelido)
                .HasColumnType("varchar(30)");
            builder.Property(p => p.Ativo)
                .ValueGeneratedOnAdd();
            builder.Property(p => p.IniciadoEm)
                .HasDefaultValueSql("GETDATE()")
                .ValueGeneratedOnAdd();
            builder.Property(p => p.FinalizadoEm);
            builder.Property(p => p.EquipeId);

            builder.HasMany(p => p.Colaboradores)
                .WithOne(p => p.Projeto)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
