using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PruebaKhensys.Core.Entities.Models;
using System;

namespace PruebaKhensys.Infrastructure.Persistence.Context.EntityConfigurations
{
    public class EmployeesEntityTypeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.LastName).IsRequired();
            builder.Property(p => p.Date).IsRequired();
            builder.Property(p => p.Date).HasDefaultValue(DateTime.Now);
        }
    }
}
