﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using livraria.Repositorio;

namespace livraria.Migrations
{
    [DbContext(typeof(LivrariaContexto))]
    [Migration("20190225114707_teste")]
    partial class teste
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("livraria.Models.Aluguel", b =>
                {
                    b.Property<Guid>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("co_aluguel");

                    b.Property<Guid>("ClienteId")
                        .HasColumnName("co_cliente");

                    b.Property<DateTime>("DataDeEntrega")
                        .HasColumnName("de_aluguel");

                    b.Property<DateTime>("DataDeRetirada")
                        .HasColumnName("dr_aluguel");

                    b.Property<Guid>("LivroId")
                        .HasColumnName("co_livro");

                    b.Property<bool>("Status")
                        .HasColumnName("st_aluguel");

                    b.HasKey("Codigo");

                    b.HasIndex("ClienteId");

                    b.HasIndex("LivroId");

                    b.ToTable("aluguel","livraria");
                });

            modelBuilder.Entity("livraria.Models.Cliente", b =>
                {
                    b.Property<Guid>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("co_cliente");

                    b.Property<string>("Cpf")
                        .HasColumnName("cpf_cliente");

                    b.Property<DateTime>("DataDeNascimento")
                        .HasColumnName("dtn_cliente");

                    b.Property<string>("Nome")
                        .HasColumnName("nm_cliente");

                    b.HasKey("Codigo");

                    b.ToTable("cliente","livraria");
                });

            modelBuilder.Entity("livraria.Models.Livro", b =>
                {
                    b.Property<Guid>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("co_livro");

                    b.Property<string>("Autor")
                        .HasColumnName("au_livro");

                    b.Property<string>("Descricao")
                        .HasColumnName("ds_livro");

                    b.Property<string>("Nome")
                        .HasColumnName("nm_livro");

                    b.HasKey("Codigo");

                    b.ToTable("livro","livraria");
                });

            modelBuilder.Entity("livraria.Models.Aluguel", b =>
                {
                    b.HasOne("livraria.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("livraria.Models.Livro", "Livro")
                        .WithMany()
                        .HasForeignKey("LivroId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
