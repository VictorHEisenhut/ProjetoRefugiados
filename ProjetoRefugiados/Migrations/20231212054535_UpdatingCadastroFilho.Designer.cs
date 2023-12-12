﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjetoRefugiados.Data;

#nullable disable

namespace ProjetoRefugiados.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231212054535_UpdatingCadastroFilho")]
    partial class UpdatingCadastroFilho
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ProjetoRefugiados.Models.Abrigo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("EnderecoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EnderecoId");

                    b.ToTable("Abrigos");
                });

            modelBuilder.Entity("ProjetoRefugiados.Models.Cadastro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("DocumentoId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Escolaridade")
                        .HasColumnType("int");

                    b.Property<int>("EstadoCivil")
                        .HasColumnType("int");

                    b.Property<int?>("FilhoId")
                        .HasColumnType("int");

                    b.Property<int>("Genero")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("PaisId")
                        .HasColumnType("int");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("DocumentoId");

                    b.HasIndex("FilhoId");

                    b.HasIndex("PaisId");

                    b.ToTable("Cadastros");
                });

            modelBuilder.Entity("ProjetoRefugiados.Models.CadastroFilho", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Escolaridade")
                        .HasColumnType("int");

                    b.Property<int>("Genero")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("PaisId")
                        .HasColumnType("int");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("PaisId");

                    b.ToTable("CadastroFilho");
                });

            modelBuilder.Entity("ProjetoRefugiados.Models.Consulado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("EnderecoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EnderecoId");

                    b.ToTable("Consulados");
                });

            modelBuilder.Entity("ProjetoRefugiados.Models.Documento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Cnh")
                        .HasColumnType("longtext");

                    b.Property<string>("Cpf")
                        .HasColumnType("longtext");

                    b.Property<string>("Crnm")
                        .HasColumnType("longtext");

                    b.Property<string>("Dprnm")
                        .HasColumnType("longtext");

                    b.Property<string>("ProtocoleRefugio")
                        .HasColumnType("longtext");

                    b.Property<string>("RegistroEmigrante")
                        .HasColumnType("longtext");

                    b.Property<string>("Rg")
                        .HasColumnType("longtext");

                    b.Property<string>("Rne")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Documentos");
                });

            modelBuilder.Entity("ProjetoRefugiados.Models.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("ProjetoRefugiados.Models.Paises", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Country")
                        .HasColumnType("longtext");

                    b.Property<string>("Pais")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Paises");
                });

            modelBuilder.Entity("ProjetoRefugiados.Models.PostoDeSaude", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("EnderecoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EnderecoId");

                    b.ToTable("PostosDeSaude");
                });

            modelBuilder.Entity("ProjetoRefugiados.Models.Abrigo", b =>
                {
                    b.HasOne("ProjetoRefugiados.Models.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("ProjetoRefugiados.Models.Cadastro", b =>
                {
                    b.HasOne("ProjetoRefugiados.Models.Documento", "Documento")
                        .WithMany()
                        .HasForeignKey("DocumentoId");

                    b.HasOne("ProjetoRefugiados.Models.CadastroFilho", "Filho")
                        .WithMany()
                        .HasForeignKey("FilhoId");

                    b.HasOne("ProjetoRefugiados.Models.Paises", "Pais")
                        .WithMany()
                        .HasForeignKey("PaisId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Documento");

                    b.Navigation("Filho");

                    b.Navigation("Pais");
                });

            modelBuilder.Entity("ProjetoRefugiados.Models.CadastroFilho", b =>
                {
                    b.HasOne("ProjetoRefugiados.Models.Paises", "Pais")
                        .WithMany()
                        .HasForeignKey("PaisId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pais");
                });

            modelBuilder.Entity("ProjetoRefugiados.Models.Consulado", b =>
                {
                    b.HasOne("ProjetoRefugiados.Models.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("ProjetoRefugiados.Models.PostoDeSaude", b =>
                {
                    b.HasOne("ProjetoRefugiados.Models.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Endereco");
                });
#pragma warning restore 612, 618
        }
    }
}
