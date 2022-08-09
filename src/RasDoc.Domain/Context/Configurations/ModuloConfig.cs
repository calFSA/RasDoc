using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rasdoc.Entities.Models;

namespace MatrizDeRastreabilidade.API.Data.Configurations
{
    public class ModuloConfig : IEntityTypeConfiguration<Modulo>
    {
        public void Configure(EntityTypeBuilder<Modulo> builder)
        {
            builder.ToTable("Modulo");
            builder.HasKey("Id");
            builder.Property(p => p.Nome)
                .HasColumnType("varchar(50)");
            builder.Property(p => p.Codigo)
                .HasColumnType("varchar(50)");
        }
    }
}
