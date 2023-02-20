﻿// <auto-generated />
using System;
using Api.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace application.Migrations
{
    [DbContext(typeof(MyContext))]
    partial class MyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Api.Domain.Entities.Agent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime(6)");

                    b.Property<long>("Cpf")
                        .HasMaxLength(11)
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Rg")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("varchar(9)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("Cpf")
                        .IsUnique();

                    b.ToTable("Agent", (string)null);
                });

            modelBuilder.Entity("Api.Domain.Entities.Person", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime(6)");

                    b.Property<long>("Cpf")
                        .HasMaxLength(11)
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Rg")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("varchar(9)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("Cpf")
                        .IsUnique();

                    b.ToTable("Person", (string)null);
                });

            modelBuilder.Entity("Api.Domain.Entities.ResidencialProperty", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("Cep")
                        .HasMaxLength(8)
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Complement")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Hidrometer")
                        .HasColumnType("int");

                    b.Property<string>("Neighborhood")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("Number")
                        .HasColumnType("int");

                    b.Property<Guid>("PersonId")
                        .HasColumnType("char(36)");

                    b.Property<int>("Rgi")
                        .HasColumnType("int");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.HasIndex("Rgi")
                        .IsUnique();

                    b.ToTable("Residencial_Property", (string)null);
                });

            modelBuilder.Entity("Api.Domain.Entities.TechnicalVisit", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("AgentId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("Homologated")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("HomologationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Observation")
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<DateTime>("RequestDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("ResidencialPropertyId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("ReturnDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("VisitDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("AgentId");

                    b.HasIndex("ResidencialPropertyId");

                    b.ToTable("Technical_Visit", (string)null);
                });

            modelBuilder.Entity("Api.Domain.Entities.ResidencialProperty", b =>
                {
                    b.HasOne("Api.Domain.Entities.Person", "Person")
                        .WithMany("ResidencialProperties")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("Api.Domain.Entities.TechnicalVisit", b =>
                {
                    b.HasOne("Api.Domain.Entities.Agent", "Agent")
                        .WithMany("Visits")
                        .HasForeignKey("AgentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api.Domain.Entities.ResidencialProperty", "ResidencialProperty")
                        .WithMany()
                        .HasForeignKey("ResidencialPropertyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Agent");

                    b.Navigation("ResidencialProperty");
                });

            modelBuilder.Entity("Api.Domain.Entities.Agent", b =>
                {
                    b.Navigation("Visits");
                });

            modelBuilder.Entity("Api.Domain.Entities.Person", b =>
                {
                    b.Navigation("ResidencialProperties");
                });
#pragma warning restore 612, 618
        }
    }
}
