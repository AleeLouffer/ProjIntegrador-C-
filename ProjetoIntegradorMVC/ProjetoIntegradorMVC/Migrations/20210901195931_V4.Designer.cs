﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjetoIntegradorMVC.Models.ContextoDb;

namespace ProjetoIntegradorMVC.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20210901195931_V4")]
    partial class V4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProjetoIntegradorMVC.Models.LigaçãoModels.FuncionariosComServicos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdFuncionario")
                        .HasColumnType("int");

                    b.Property<int>("IdServico")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("FuncionariosComServicos");
                });

            modelBuilder.Entity("ProjetoIntegradorMVC.Models.Operacoes.Servico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FuncionariosComServicosId")
                        .HasColumnType("int");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("FuncionariosComServicosId");

                    b.ToTable("Servico");
                });

            modelBuilder.Entity("ProjetoIntegradorMVC.Models.Usuarios.Funcionario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("FuncionariosComServicosId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FuncionariosComServicosId");

                    b.ToTable("Funcionarios");
                });

            modelBuilder.Entity("ProjetoIntegradorMVC.Models.Operacoes.Servico", b =>
                {
                    b.HasOne("ProjetoIntegradorMVC.Models.LigaçãoModels.FuncionariosComServicos", null)
                        .WithMany("Servicos")
                        .HasForeignKey("FuncionariosComServicosId");
                });

            modelBuilder.Entity("ProjetoIntegradorMVC.Models.Usuarios.Funcionario", b =>
                {
                    b.HasOne("ProjetoIntegradorMVC.Models.LigaçãoModels.FuncionariosComServicos", null)
                        .WithMany("Funcionarios")
                        .HasForeignKey("FuncionariosComServicosId");
                });

            modelBuilder.Entity("ProjetoIntegradorMVC.Models.LigaçãoModels.FuncionariosComServicos", b =>
                {
                    b.Navigation("Funcionarios");

                    b.Navigation("Servicos");
                });
#pragma warning restore 612, 618
        }
    }
}
