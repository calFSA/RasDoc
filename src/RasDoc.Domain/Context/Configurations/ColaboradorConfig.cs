using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rasdoc.Entities.Models;

namespace RasDoc.Domain.Context.Configurations
{
    public class ColaboradorConfig : IEntityTypeConfiguration<Colaborador>
    {
        public void Configure(EntityTypeBuilder<Colaborador> builder)
        {
            builder.ToTable("Colaborador");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Nome)
                .HasColumnType("varchar(50)");
            builder.Property(c => c.DataAlt)
                .HasColumnType("Timestamp");
            builder.Property(c => c.Ativo)
                .HasColumnType("integer");

            builder.HasMany(x => x.ProjetosColaborador)
               .WithOne(x => x.Colaborador)
               .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
