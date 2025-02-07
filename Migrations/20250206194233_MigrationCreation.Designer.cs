﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using rootBooks.Data;

#nullable disable

namespace rootBooks.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250206194233_MigrationCreation")]
    partial class MigrationCreation
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("rootBooks.Models.Cliente", b =>
                {
                    b.Property<int>("IdCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCliente"));

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nmCliente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCliente");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("rootBooks.Models.Produto", b =>
                {
                    b.Property<int>("idProduto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idProduto"));

                    b.Property<string>("dscProduto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("vlrUnitario")
                        .HasColumnType("decimal(18,4)");

                    b.HasKey("idProduto");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("rootBooks.Models.Venda", b =>
                {
                    b.Property<int>("idVenda")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idVenda"));

                    b.Property<int?>("ClienteIdCliente")
                        .HasColumnType("int");

                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.Property<int?>("ProdutoidProduto")
                        .HasColumnType("int");

                    b.Property<DateTime>("dthVenda")
                        .HasColumnType("datetime2");

                    b.Property<int>("idProduto")
                        .HasColumnType("int");

                    b.Property<int>("qtdVenda")
                        .HasColumnType("int");

                    b.Property<decimal>("vlrUnitarioVenda")
                        .HasColumnType("decimal(18,4)");

                    b.HasKey("idVenda");

                    b.HasIndex("ClienteIdCliente");

                    b.HasIndex("ProdutoidProduto");

                    b.ToTable("Vendas");
                });

            modelBuilder.Entity("rootBooks.Models.Venda", b =>
                {
                    b.HasOne("rootBooks.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteIdCliente");

                    b.HasOne("rootBooks.Models.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoidProduto");

                    b.Navigation("Cliente");

                    b.Navigation("Produto");
                });
#pragma warning restore 612, 618
        }
    }
}
