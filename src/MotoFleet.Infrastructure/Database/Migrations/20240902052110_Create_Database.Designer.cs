﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MotoFleet.Infrastructure.Database;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MotoFleet.Infrastructure.Database.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240902052110_Create_Database")]
    partial class Create_Database
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("public")
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MotoFleet.Domain.DeliveryPersons.DeliveryPerson", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Cnh")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CnhType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CnpjCpf")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateBirth")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Cnh")
                        .IsUnique();

                    b.HasIndex("CnpjCpf")
                        .IsUnique();

                    b.ToTable("DeliveryPersons", "public");
                });

            modelBuilder.Entity("MotoFleet.Domain.Motorcycles.Motorcycle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Plate")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Year")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Plate")
                        .IsUnique();

                    b.ToTable("Motorcycles", "public");
                });

            modelBuilder.Entity("MotoFleet.Domain.Plans.Plan", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<decimal>("FinePercentage")
                        .HasColumnType("numeric");

                    b.Property<int>("NumberDays")
                        .HasColumnType("integer");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("Plans", "public");

                    b.HasData(
                        new
                        {
                            Id = new Guid("5b8f8d85-5f53-4171-9781-b6aac9acd775"),
                            FinePercentage = 20m,
                            NumberDays = 7,
                            Price = 30m
                        },
                        new
                        {
                            Id = new Guid("57193539-b9f1-49cc-a06d-28a1d7842041"),
                            FinePercentage = 40m,
                            NumberDays = 15,
                            Price = 28m
                        },
                        new
                        {
                            Id = new Guid("14170a49-3a12-4eba-b24c-6f36f34e9c76"),
                            FinePercentage = 40m,
                            NumberDays = 30,
                            Price = 22m
                        },
                        new
                        {
                            Id = new Guid("0568d77d-285b-43a5-8a70-6e0223d5d05d"),
                            FinePercentage = 40m,
                            NumberDays = 45,
                            Price = 20m
                        },
                        new
                        {
                            Id = new Guid("ff361b97-769f-42fc-badf-0ead1e8df8e4"),
                            FinePercentage = 40m,
                            NumberDays = 50,
                            Price = 18m
                        });
                });

            modelBuilder.Entity("MotoFleet.Domain.Rentals.Rental", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<decimal?>("CalculatedPrice")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("DeliveryPersonId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("ExpectedEndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsReturned")
                        .HasColumnType("boolean");

                    b.Property<Guid>("MotorcycleId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PlanId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("DeliveryPersonId");

                    b.HasIndex("MotorcycleId");

                    b.HasIndex("PlanId");

                    b.ToTable("Rentals", "public");
                });

            modelBuilder.Entity("MotoFleet.Domain.Rentals.Rental", b =>
                {
                    b.HasOne("MotoFleet.Domain.DeliveryPersons.DeliveryPerson", null)
                        .WithMany()
                        .HasForeignKey("DeliveryPersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MotoFleet.Domain.Motorcycles.Motorcycle", null)
                        .WithMany()
                        .HasForeignKey("MotorcycleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MotoFleet.Domain.Plans.Plan", null)
                        .WithMany()
                        .HasForeignKey("PlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
