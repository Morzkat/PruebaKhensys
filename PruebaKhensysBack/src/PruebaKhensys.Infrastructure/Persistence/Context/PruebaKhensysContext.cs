using Microsoft.EntityFrameworkCore;
using PruebaKhensys.Core.Entities.Models;

namespace PruebaKhensys.Infrastructure.Persistence.Context
{
    public class PruebaKhensysContext : DbContext
    {
        public PruebaKhensysContext(DbContextOptions<PruebaKhensysContext> options) : base (options)
        {

        }

        //TODO: Add fluent validation.

        public DbSet<Role> Roles { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}

