﻿// <auto-generated />
using CadastroProdutos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CadastroProdutos.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20220715183719_Atualizacao")]
    partial class Atualizacao
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CadastroProdutos.Models.DefSituacaoProduto", b =>
                {
                    b.Property<int>("SituacaoProdutoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SituacaoProdutoId"), 1L, 1);

                    b.Property<string>("DescricaoSituacao")
                        .IsRequired()
                        .HasColumnType("varchar(32)");

                    b.HasKey("SituacaoProdutoId");

                    b.ToTable("DefSituacaoProduto");
                });

            modelBuilder.Entity("CadastroProdutos.Models.DefSituacaoProdutoEmbalagem", b =>
                {
                    b.Property<int>("SituacaoProdutoEmbalagemID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SituacaoProdutoEmbalagemID"), 1L, 1);

                    b.Property<string>("DescricaoSituacao")
                        .IsRequired()
                        .HasColumnType("varchar(32)");

                    b.HasKey("SituacaoProdutoEmbalagemID");

                    b.ToTable("DefSituacaoProdutoEmbalagem");
                });

            modelBuilder.Entity("CadastroProdutos.Models.DefUnidadeComercial", b =>
                {
                    b.Property<int>("UnidadeComercialID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UnidadeComercialID"), 1L, 1);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(32)");

                    b.HasKey("UnidadeComercialID");

                    b.ToTable("DefUnidadeComercial");
                });

            modelBuilder.Entity("CadastroProdutos.Models.Produto", b =>
                {
                    b.Property<int>("ProdutoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProdutoId"), 1L, 1);

                    b.Property<int>("DefSituacaoProdutoId")
                        .HasColumnType("int");

                    b.Property<int>("DefUnidadeComercialId")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(120)");

                    b.Property<decimal>("PesoLiquido")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ProdutoId");

                    b.HasIndex("DefSituacaoProdutoId");

                    b.HasIndex("DefUnidadeComercialId");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("CadastroProdutos.Models.ProdutoEmbalagem", b =>
                {
                    b.Property<int>("ProdutoEmbalagemID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProdutoEmbalagemID"), 1L, 1);

                    b.Property<int>("DefSituacaoProdutoEmbalagemSituacaoProdutoEmbalagemID")
                        .HasColumnType("int");

                    b.Property<decimal>("FatorDeConversao")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("int");

                    b.HasKey("ProdutoEmbalagemID");

                    b.HasIndex("DefSituacaoProdutoEmbalagemSituacaoProdutoEmbalagemID");

                    b.HasIndex("ProdutoId");

                    b.ToTable("ProdutoEmbalagens");
                });

            modelBuilder.Entity("CadastroProdutos.Models.Produto", b =>
                {
                    b.HasOne("CadastroProdutos.Models.DefSituacaoProduto", "DefSituacaoProduto")
                        .WithMany("Produtos")
                        .HasForeignKey("DefSituacaoProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CadastroProdutos.Models.DefUnidadeComercial", "DefUnidadeComercial")
                        .WithMany("Produtos")
                        .HasForeignKey("DefUnidadeComercialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DefSituacaoProduto");

                    b.Navigation("DefUnidadeComercial");
                });

            modelBuilder.Entity("CadastroProdutos.Models.ProdutoEmbalagem", b =>
                {
                    b.HasOne("CadastroProdutos.Models.DefSituacaoProdutoEmbalagem", "DefSituacaoProdutoEmbalagem")
                        .WithMany("ProdutoEmbalagens")
                        .HasForeignKey("DefSituacaoProdutoEmbalagemSituacaoProdutoEmbalagemID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CadastroProdutos.Models.Produto", "Produto")
                        .WithMany("ProdutoEmbalagems")
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DefSituacaoProdutoEmbalagem");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("CadastroProdutos.Models.DefSituacaoProduto", b =>
                {
                    b.Navigation("Produtos");
                });

            modelBuilder.Entity("CadastroProdutos.Models.DefSituacaoProdutoEmbalagem", b =>
                {
                    b.Navigation("ProdutoEmbalagens");
                });

            modelBuilder.Entity("CadastroProdutos.Models.DefUnidadeComercial", b =>
                {
                    b.Navigation("Produtos");
                });

            modelBuilder.Entity("CadastroProdutos.Models.Produto", b =>
                {
                    b.Navigation("ProdutoEmbalagems");
                });
#pragma warning restore 612, 618
        }
    }
}