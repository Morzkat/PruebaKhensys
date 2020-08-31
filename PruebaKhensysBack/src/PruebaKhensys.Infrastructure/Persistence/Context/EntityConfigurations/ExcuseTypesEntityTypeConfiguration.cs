using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PruebaKhensys.Core.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaKhensys.Infrastructure.Persistence.Context.EntityConfigurations
{
    public class ExcuseTypesEntityTypeConfiguration : IEntityTypeConfiguration<ExcuseType>
    {
        public void Configure(EntityTypeBuilder<ExcuseType> builder)
        {
            builder.Property(p => p.Description).IsRequired();
        }
    }
}
