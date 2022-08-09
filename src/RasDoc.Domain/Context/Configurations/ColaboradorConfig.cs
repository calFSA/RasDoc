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
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Nome)
                .HasColumnType("varchar(50)");

            builder.HasMany(x => x.ProjetoColaborador)
               .WithOne(x => x.Colaborador)
               .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
