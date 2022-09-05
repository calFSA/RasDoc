using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Rasdoc.Entities.Models;
using System.Diagnostics;

namespace RasDoc.Domain.Context
{
    public class ApplicationDbContext : IdentityDbContext
    {
        #region DbSet's
        public DbSet<Colaborador>? Colaborador { get; set; }
        public DbSet<Equipe>? Equipe { get; set; }
        public DbSet<Projeto>? Projeto { get; set; }
        public DbSet<ProjetoColaborador>? ProjetoColaborador { get; set; }
        #endregion

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            //modelBuilder.Entity<>().HasData(new List<>
            //{
            //});
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(message => Debug.WriteLine(message));
        }
    }
}
