using MatrizDeRastreabilidade.API.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MatrizDeRastreabilidade.API.Data.Configurations
{
    public class EquipeConfiguration : IEntityTypeConfiguration<Equipe>
    {
        public void Configure(EntityTypeBuilder<Equipe> builder)
        {
            builder.ToTable("Equipe");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.IniciadoEm)
                .HasDefaultValueSql("GETDATE()")
                .ValueGeneratedOnAdd();
            builder.Property(p => p.Nome)
                .HasColumnType("varchar(50)");
        }
    }
}
