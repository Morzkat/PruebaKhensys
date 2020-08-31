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

        public DbSet<Role> Roles { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RolesEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeesEntityTypeConfiguration());

            modelBuilder.Seed();
        }
    }

    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role { Description = "Enfermedad" },
                new Role { Description = "Diligencias" }
            );
        }
    }
}

