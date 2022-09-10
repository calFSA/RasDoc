using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rasdoc.Entities.Models;

namespace RasDoc.Domain.Context.Configurations
{
    public class ProjetoColaboradorConfig : IEntityTypeConfiguration<ProjetoColaborador>
    {
        public void Configure(EntityTypeBuilder<ProjetoColaborador> builder)
        {
            builder.ToTable("ProjetoColaborador");
            builder.HasKey(pc => pc.Id);
            builder.Property(pc => pc.IniciadoEm)
                .HasColumnType("Timestamp")
                .HasDefaultValueSql("datetime('now', 'localtime')")
                .ValueGeneratedOnAdd();
            builder.Property(pc => pc.FinalizadoEm);

            builder.HasOne<Projeto>(p => p.Projeto)
                .WithMany(pc => pc.ProjetosColaborador)
                .HasForeignKey(pc => pc.ProjetoId);

            builder.HasOne<Colaborador>(c => c.Colaborador)
                .WithMany(pc => pc.ProjetosColaborador)
                .HasForeignKey(pc => pc.ColaboradorId);
        }
    }
}
