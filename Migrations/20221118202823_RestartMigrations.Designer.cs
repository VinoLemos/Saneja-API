﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Projeto_SaneJa.Context;

#nullable disable

namespace Projeto_SaneJa.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20221118202823_RestartMigrations")]
    partial class RestartMigrations
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Projeto_SaneJa.Models.AgenteDeSaneamento", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("varchar(11)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Matricula")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.Property<string>("Rg")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("varchar(9)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("varchar(11)");

                    b.HasKey("ID");

                    b.ToTable("Agentes");
                });

            modelBuilder.Entity("Projeto_SaneJa.Models.Cliente", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("varchar(11)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.Property<string>("Rg")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("varchar(9)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("varchar(11)");

                    b.HasKey("ID");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Projeto_SaneJa.Models.Imovel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.Property<int>("Cep")
                        .HasColumnType("int");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Complemento")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("CpfProprietario")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("varchar(11)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Hidrometro")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("varchar(11)");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<string>("Rgi")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("varchar(11)");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.HasKey("ID");

                    b.ToTable("Imoveis");
                });

            modelBuilder.Entity("Projeto_SaneJa.Models.VisitaTecnica", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DataHomologacao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataRetorno")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataSolicitacao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataVisita")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("Homologacao")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Observacao")
                        .HasColumnType("longtext");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("cpfProprietario")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("varchar(11)");

                    b.Property<int?>("matriculaAgente")
                        .HasColumnType("int");

                    b.Property<string>("rgiImovel")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("varchar(11)");

                    b.HasKey("ID");

                    b.ToTable("Visitas");
                });
#pragma warning restore 612, 618
        }
    }
}
