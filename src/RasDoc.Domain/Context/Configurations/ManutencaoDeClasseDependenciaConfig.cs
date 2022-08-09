using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rasdoc.Entities.Models;

namespace RasDoc.Domain.Context.Configurations
{
    public class ManutencaoDeClasseDependenciaConfig : IEntityTypeConfiguration<ManutencaoDeClasseDependencia>
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
