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
            builder.Property(m => m.Nome)
                .HasColumnType("varchar(50)");
            builder.Property(m => m.Codigo)
                .HasColumnType("varchar(30)");
            builder.Property(m => m.Localizacao)
                .HasColumnType("text");
            builder.Property(m => m.DataAlt)
                .HasColumnType("Timestamp");

            builder.HasMany(mcd => mcd.ManutencaoDeClasseDependencias)
               .WithOne(mc => mc.ManutencaoDeClasse)
               .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
