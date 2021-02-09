using MatrizDeRastreabilidade.API.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MatrizDeRastreabilidade.API.Data.Configurations
{
    public class ProjetoColaboradorConfiguration : IEntityTypeConfiguration<ProjetoColaborador>
    {
        public void Configure(EntityTypeBuilder<ProjetoColaborador> builder)
        {
            builder.ToTable("ProjetoColaborador");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.IniciadoEm)
                .HasDefaultValueSql("GETDATE()")
                .ValueGeneratedOnAdd();
            builder.Property(p => p.FinalizadoEm);
        }
    }
}
