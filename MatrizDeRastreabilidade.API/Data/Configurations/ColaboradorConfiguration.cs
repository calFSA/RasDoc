using MatrizDeRastreabilidade.API.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MatrizDeRastreabilidade.API.Data.Configurations
{
    public class ColaboradorConfiguration : IEntityTypeConfiguration<Colaborador>
    {
        public void Configure(EntityTypeBuilder<Colaborador> builder)
        {
            builder.ToTable("Colaborador");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Nome)
                .HasColumnType("varchar(50)");
        }
    }
}
