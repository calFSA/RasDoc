﻿// <auto-generated />
using System;
using MatrizDeRastreabilidade.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MatrizDeRastreabilidade.API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210209221359_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("MatrizDeRastreabilidade.API.Model.Classe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Codigo")
                        .HasColumnType("varchar(30)");

                    b.Property<int>("ModuloId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("ModuloId");

                    b.ToTable("Classe");
                });

            modelBuilder.Entity("MatrizDeRastreabilidade.API.Model.Colaborador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Nome")
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Colaborador");
                });

            modelBuilder.Entity("MatrizDeRastreabilidade.API.Model.Equipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<int>("ColaboradorId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("FinalizadoEm")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("IniciadoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Nome")
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("ColaboradorId");

                    b.ToTable("Equipe");
                });

            modelBuilder.Entity("MatrizDeRastreabilidade.API.Model.ManutencaoDeClasse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Codigo")
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Localizacao")
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("ManutencaoDeClasse");
                });

            modelBuilder.Entity("MatrizDeRastreabilidade.API.Model.ManutencaoDeClasseDependencia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("ClasseId")
                        .HasColumnType("int");

                    b.Property<int>("ManutencaoDeClasseId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClasseId");

                    b.HasIndex("ManutencaoDeClasseId");

                    b.ToTable("ManutencaoDeClasseDependencia");
                });

            modelBuilder.Entity("MatrizDeRastreabilidade.API.Model.Modulo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Codigo")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Nome")
                        .HasColumnType("varchar(50)");

                    b.Property<int>("ProjetoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProjetoId");

                    b.ToTable("Modulo");
                });

            modelBuilder.Entity("MatrizDeRastreabilidade.API.Model.Projeto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Apelido")
                        .HasColumnType("varchar(30)");

                    b.Property<bool>("Ativo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit");

                    b.Property<int>("EquipeId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("FinalizadoEm")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("IniciadoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Nome")
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("EquipeId");

                    b.ToTable("Projeto");
                });

            modelBuilder.Entity("MatrizDeRastreabilidade.API.Model.ProjetoColaborador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("ColaboradorId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("FinalizadoEm")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("IniciadoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int>("ProjetoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ColaboradorId");

                    b.HasIndex("ProjetoId");

                    b.ToTable("ProjetoColaborador");
                });

            modelBuilder.Entity("MatrizDeRastreabilidade.API.Model.Classe", b =>
                {
                    b.HasOne("MatrizDeRastreabilidade.API.Model.Modulo", "Modulo")
                        .WithMany()
                        .HasForeignKey("ModuloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Modulo");
                });

            modelBuilder.Entity("MatrizDeRastreabilidade.API.Model.Equipe", b =>
                {
                    b.HasOne("MatrizDeRastreabilidade.API.Model.Colaborador", "Colaborador")
                        .WithMany()
                        .HasForeignKey("ColaboradorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Colaborador");
                });

            modelBuilder.Entity("MatrizDeRastreabilidade.API.Model.ManutencaoDeClasseDependencia", b =>
                {
                    b.HasOne("MatrizDeRastreabilidade.API.Model.Classe", "Classe")
                        .WithMany()
                        .HasForeignKey("ClasseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MatrizDeRastreabilidade.API.Model.ManutencaoDeClasse", "ManutencaoDeClasse")
                        .WithMany("ManutencaoDeClasseDependencias")
                        .HasForeignKey("ManutencaoDeClasseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Classe");

                    b.Navigation("ManutencaoDeClasse");
                });

            modelBuilder.Entity("MatrizDeRastreabilidade.API.Model.Modulo", b =>
                {
                    b.HasOne("MatrizDeRastreabilidade.API.Model.Projeto", "Projeto")
                        .WithMany()
                        .HasForeignKey("ProjetoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Projeto");
                });

            modelBuilder.Entity("MatrizDeRastreabilidade.API.Model.Projeto", b =>
                {
                    b.HasOne("MatrizDeRastreabilidade.API.Model.Equipe", "Equipe")
                        .WithMany()
                        .HasForeignKey("EquipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Equipe");
                });

            modelBuilder.Entity("MatrizDeRastreabilidade.API.Model.ProjetoColaborador", b =>
                {
                    b.HasOne("MatrizDeRastreabilidade.API.Model.Colaborador", "Colaborador")
                        .WithMany("ProjetosColaboradores")
                        .HasForeignKey("ColaboradorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("MatrizDeRastreabilidade.API.Model.Projeto", "Projeto")
                        .WithMany("Colaboradores")
                        .HasForeignKey("ProjetoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Colaborador");

                    b.Navigation("Projeto");
                });

            modelBuilder.Entity("MatrizDeRastreabilidade.API.Model.Colaborador", b =>
                {
                    b.Navigation("ProjetosColaboradores");
                });

            modelBuilder.Entity("MatrizDeRastreabilidade.API.Model.ManutencaoDeClasse", b =>
                {
                    b.Navigation("ManutencaoDeClasseDependencias");
                });

            modelBuilder.Entity("MatrizDeRastreabilidade.API.Model.Projeto", b =>
                {
                    b.Navigation("Colaboradores");
                });
#pragma warning restore 612, 618
        }
    }
}