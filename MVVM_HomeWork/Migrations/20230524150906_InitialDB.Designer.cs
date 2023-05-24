﻿// <auto-generated />
using System;
using MVVM_HomeWork.OtherFIles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MVVMHomeWork.Migrations
{
    [DbContext(typeof(HomeworkdatabaseContext))]
    [Migration("20230524150906_InitialDB")]
    partial class InitialDB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("utf8mb4_general_ci")
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.HasCharSet(modelBuilder, "utf8mb4");

            modelBuilder.Entity("MVVM_HomeWork.Category", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("category", (string)null);
                });

            modelBuilder.Entity("MVVM_HomeWork.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<decimal?>("CostOfOne")
                        .HasColumnType("decimal(19,2) unsigned");

                    b.Property<sbyte?>("Discount")
                        .HasColumnType("tinyint");

                    b.Property<int>("IdCategory")
                        .HasColumnType("int");

                    b.Property<int>("IdProvider")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "IdCategory" }, "FK_product_IdCategory");

                    b.HasIndex(new[] { "IdProvider" }, "FK_product_IdProvider");

                    b.ToTable("product", (string)null);
                });

            modelBuilder.Entity("MVVM_HomeWork.Provider", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("provider", (string)null);
                });

            modelBuilder.Entity("MVVM_HomeWork.Product", b =>
                {
                    b.HasOne("MVVM_HomeWork.Category", "IdCategoryNavigation")
                        .WithMany("Products")
                        .HasForeignKey("IdCategory")
                        .IsRequired()
                        .HasConstraintName("FK_product_IdCategory");

                    b.HasOne("MVVM_HomeWork.Provider", "IdProviderNavigation")
                        .WithMany("Products")
                        .HasForeignKey("IdProvider")
                        .IsRequired()
                        .HasConstraintName("FK_product_IdProvider");

                    b.Navigation("IdCategoryNavigation");

                    b.Navigation("IdProviderNavigation");
                });

            modelBuilder.Entity("MVVM_HomeWork.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("MVVM_HomeWork.Provider", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}