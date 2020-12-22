﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PruebaKhensys.Infrastructure.Persistence.Context;

namespace PruebaKhensys.Infrastructure.Persistence.Context.Migrations
{
    [DbContext(typeof(PruebaKhensysContext))]
    [Migration("20200830033647_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PruebaKhensys.Core.Entities.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2020, 8, 29, 23, 36, 46, 725, DateTimeKind.Local).AddTicks(8142));

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ExcuseTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ExcuseTypeId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("PruebaKhensys.Core.Entities.Models.ExcuseType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ExcuseTypes");
                });

            modelBuilder.Entity("PruebaKhensys.Core.Entities.Models.Employee", b =>
                {
                    b.HasOne("PruebaKhensys.Core.Entities.Models.ExcuseType", "ExcuseType")
                        .WithMany()
                        .HasForeignKey("ExcuseTypeId");
                });
#pragma warning restore 612, 618
        }
    }
}
