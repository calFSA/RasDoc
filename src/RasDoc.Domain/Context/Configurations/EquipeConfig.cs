using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rasdoc.Entities.Models;

namespace RasDoc.Domain.Context.Configurations
{
    public class EquipeConfig : IEntityTypeConfiguration<Equipe>
    {
        public void Configure(EntityTypeBuilder<Equipe> builder)
        {
            builder.ToTable("Equipe");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.IniciadoEm)
                .HasDefaultValueSql("datetime('now', 'localtime')")
                .ValueGeneratedOnAdd();
            builder.Property(p => p.Nome)
                .HasColumnType("varchar(50)");
        }
    }
}
