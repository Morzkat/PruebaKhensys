using Microsoft.EntityFrameworkCore;
using PruebaKhensys.Core.Entities.Models;
using PruebaKhensys.Infrastructure.Persistence.Context.EntityConfigurations;

namespace PruebaKhensys.Infrastructure.Persistence.Context
{
    public class PruebaKhensysContext : DbContext
    {
        public PruebaKhensysContext(DbContextOptions<PruebaKhensysContext> options) : base(options)
        {

        }

        public DbSet<ExcuseType> ExcuseTypes { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ExcuseTypesEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeesEntityTypeConfiguration());

            modelBuilder.Seed();
        }
    }

    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExcuseType>().HasData(
                new ExcuseType { Id = -1, Description = "Enfermedad" },
                new ExcuseType { Id = 0, Description = "Diligencias" }
            );
        }
    }
}

