using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rasdoc.Entities.Models;

namespace RasDoc.Domain.Context.Configurations
{
    public class ClasseConfig : IEntityTypeConfiguration<Classe>
    {
        public void Configure(EntityTypeBuilder<Classe> builder)
        {
            builder.ToTable("Classe");
            builder.HasKey("Id");
            builder.Property(p => p.Nome)
                .HasColumnType("varchar(50)");
            builder.Property(p => p.Codigo)
                .HasColumnType("varchar(30)");
            builder.Property(c => c.DataAlt)
                .HasColumnType("Timestamp");
        }
    }
}
