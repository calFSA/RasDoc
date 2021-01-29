using MatrizDeRastreabilidade.API.Model;
using Microsoft.EntityFrameworkCore;

namespace MatrizDeRastreabilidade.API.Data
{
    public class DataContext : DbContext
    {
        //public DbSet<ManutencaoDeClasseDependencia> ManutencaoDeClasseDependencias { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
        }
    }
}
