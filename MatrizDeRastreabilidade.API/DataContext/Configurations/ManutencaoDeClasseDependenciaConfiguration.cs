using MatrizDeRastreabilidade.API.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MatrizDeRastreabilidade.API.Data.Configurations
{
    public class ManutencaoDeClasseDependenciaConfiguration : IEntityTypeConfiguration<ManutencaoDeClasseDependencia>
    {
        public void Configure(EntityTypeBuilder<ManutencaoDeClasseDependencia> builder)
        {
            builder.ToTable("ManutencaoDeClasseDependencia");
            builder.HasKey("Id");
            builder.Property(p => p.ClasseId)
                .HasColumnType("int");
        }
    }
}
