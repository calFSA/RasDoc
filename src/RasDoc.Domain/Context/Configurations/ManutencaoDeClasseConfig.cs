using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rasdoc.Entities.Models;

namespace MatrizDeRastreabilidade.API.Data.Configurations
{
    public class ManutencaoDeClasseConfig : IEntityTypeConfiguration<ManutencaoDeClasse>
    {
        public void Configure(EntityTypeBuilder<ManutencaoDeClasse> builder)
        {
            builder.ToTable("ManutencaoDeClasse");
            builder.HasKey("Id");
            builder.Property(p => p.Nome)
                .HasColumnType("varchar(50)");
            builder.Property(p => p.Codigo)
                .HasColumnType("varchar(30)");
            builder.Property(p => p.Localizacao)
                .HasColumnType("text");
        }
    }
}
