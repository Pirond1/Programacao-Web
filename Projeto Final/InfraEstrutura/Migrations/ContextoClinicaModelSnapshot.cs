﻿// <auto-generated />
using System;
using InfraEstrutura.Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InfraEstrutura.Migrations
{
    [DbContext(typeof(ContextoClinica))]
    partial class ContextoClinicaModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Entidades.Area", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("descricao")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("id");

                    b.ToTable("Area", (string)null);
                });

            modelBuilder.Entity("Entidades.Cliente", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("cpf")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.Property<DateOnly>("dataNascimento")
                        .HasColumnType("date");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("telefone")
                        .IsRequired()
                        .HasMaxLength(19)
                        .HasColumnType("nvarchar(19)");

                    b.HasKey("id");

                    b.ToTable("Cliente", (string)null);
                });

            modelBuilder.Entity("Entidades.Consulta", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime>("dataConsulta")
                        .HasColumnType("datetime2");

                    b.Property<int>("horas")
                        .HasColumnType("int");

                    b.Property<int>("idCliente")
                        .HasColumnType("int");

                    b.Property<int>("idFuncionario")
                        .HasColumnType("int");

                    b.Property<int>("idPagamento")
                        .HasColumnType("int");

                    b.Property<int>("idServico")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("idCliente");

                    b.HasIndex("idFuncionario");

                    b.HasIndex("idPagamento");

                    b.HasIndex("idServico");

                    b.ToTable("Consulta", (string)null);
                });

            modelBuilder.Entity("Entidades.Funcionario", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateOnly>("dataNascimento")
                        .HasColumnType("date");

                    b.Property<int>("idArea")
                        .HasColumnType("int");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("salario")
                        .HasPrecision(8, 2)
                        .HasColumnType("decimal(8,2)");

                    b.HasKey("id");

                    b.HasIndex("idArea");

                    b.ToTable("Funcionario", (string)null);
                });

            modelBuilder.Entity("Entidades.Pagamento", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("descricao")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("id");

                    b.ToTable("Pagamento", (string)null);
                });

            modelBuilder.Entity("Entidades.Servico", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("descricao")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("idArea")
                        .HasColumnType("int");

                    b.Property<decimal>("valorHora")
                        .HasPrecision(8, 2)
                        .HasColumnType("decimal(8,2)");

                    b.HasKey("id");

                    b.HasIndex("idArea");

                    b.ToTable("Serviço", (string)null);
                });

            modelBuilder.Entity("Entidades.Consulta", b =>
                {
                    b.HasOne("Entidades.Cliente", "cliente")
                        .WithMany("consultas")
                        .HasForeignKey("idCliente")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_Consulta_Cliente");

                    b.HasOne("Entidades.Funcionario", "funcionario")
                        .WithMany("consultas")
                        .HasForeignKey("idFuncionario")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_Consulta_Funcionario");

                    b.HasOne("Entidades.Pagamento", "pagamento")
                        .WithMany("consultas")
                        .HasForeignKey("idPagamento")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_Consulta_Pagamento");

                    b.HasOne("Entidades.Servico", "servico")
                        .WithMany("consultas")
                        .HasForeignKey("idServico")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_Consulta_Serviço");

                    b.Navigation("cliente");

                    b.Navigation("funcionario");

                    b.Navigation("pagamento");

                    b.Navigation("servico");
                });

            modelBuilder.Entity("Entidades.Funcionario", b =>
                {
                    b.HasOne("Entidades.Area", "area")
                        .WithMany("funcionarios")
                        .HasForeignKey("idArea")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_Funcionario_Area");

                    b.Navigation("area");
                });

            modelBuilder.Entity("Entidades.Servico", b =>
                {
                    b.HasOne("Entidades.Area", "area")
                        .WithMany("servicos")
                        .HasForeignKey("idArea")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_Serviço_Area");

                    b.Navigation("area");
                });

            modelBuilder.Entity("Entidades.Area", b =>
                {
                    b.Navigation("funcionarios");

                    b.Navigation("servicos");
                });

            modelBuilder.Entity("Entidades.Cliente", b =>
                {
                    b.Navigation("consultas");
                });

            modelBuilder.Entity("Entidades.Funcionario", b =>
                {
                    b.Navigation("consultas");
                });

            modelBuilder.Entity("Entidades.Pagamento", b =>
                {
                    b.Navigation("consultas");
                });

            modelBuilder.Entity("Entidades.Servico", b =>
                {
                    b.Navigation("consultas");
                });
#pragma warning restore 612, 618
        }
    }
}
