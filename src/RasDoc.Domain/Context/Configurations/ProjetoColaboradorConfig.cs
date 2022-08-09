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
            builder.HasKey(p => p.Id);
            builder.Property(p => p.IniciadoEm)
                .HasDefaultValueSql("datetime('now', 'localtime')")
                .ValueGeneratedOnAdd();
            builder.Property(p => p.FinalizadoEm);
        }
    }
}
