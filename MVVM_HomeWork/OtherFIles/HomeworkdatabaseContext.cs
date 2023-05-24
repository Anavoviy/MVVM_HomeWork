using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MVVM_HomeWork.OtherFIles;

public partial class HomeworkdatabaseContext : DbContext
{
    public HomeworkdatabaseContext()
    {
        Database.EnsureCreated();
    }

    public HomeworkdatabaseContext(DbContextOptions<HomeworkdatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Provider> Providers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;user=root;password=Anavoviy_5002;database=HomeDB", ServerVersion.Parse("8.0.31-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("category");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Title).HasMaxLength(255);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("product");

            entity.HasIndex(e => e.IdCategory, "FK_product_IdCategory");

            entity.HasIndex(e => e.IdProvider, "FK_product_IdProvider");

            entity.Property(e => e.CostOfOne).HasColumnType("decimal(19,2) unsigned");
            entity.Property(e => e.Title).HasMaxLength(255);

            entity.HasOne(d => d.IdCategoryNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdCategory)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_product_IdCategory");

            entity.HasOne(d => d.IdProviderNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdProvider)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_product_IdProvider");
        });

        modelBuilder.Entity<Provider>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("provider");

            entity.Property(e => e.Title).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);

        modelBuilder.Entity<Category>().HasData(
            new Category() { Id = 1, Title="литература"},
            new Category() { Id = 2, Title = "техника" },
            new Category() { Id = 3, Title = "спортивные товары" },
            new Category() { Id = 4, Title = "продукты питания" },
            new Category() { Id = 5, Title = "товары для школы" },
            new Category() { Id = 6, Title = "бытовая техника" },
            new Category() { Id = 7, Title = "товары для здоровья" },
            new Category() { Id = 8, Title = "товары для красоты" },
            new Category() { Id = 9, Title = "товары для кухни" },
            new Category() { Id = 10, Title = "товары для творчества" },
            new Category() { Id = 11, Title = "компьютеры и комплектующие" },
            new Category() { Id = 12, Title = "кухонная техника" },
            new Category() { Id = 13, Title = "аудиотехника" },
            new Category() { Id = 14, Title = "товары для дома" }
            );
        modelBuilder.Entity<Provider>().HasData(
            new Provider() { Id = 1, Title = "Apple"},
            new Provider() { Id = 2, Title = "ASICS" },
            new Provider() { Id = 3, Title = "ASUS" },
            new Provider() { Id = 4, Title = "Davidoff" },
            new Provider() { Id = 5, Title = "Ferrero" },
            new Provider() { Id = 6, Title = "IKEA" },
            new Provider() { Id = 7, Title = "JBL" },
            new Provider() { Id = 8, Title = "Koh-I-Noor" },
            new Provider() { Id = 9, Title = "LG" },
            new Provider() { Id = 10, Title = "L'Oreal" },
            new Provider() { Id = 11, Title = "Philips" },
            new Provider() { Id = 12, Title = "Tefal" },
            new Provider() { Id = 13, Title = "Under Armor" },
            new Provider() { Id = 14, Title = "Блумсбери" },
            new Provider() { Id = 15, Title = "Dell" },
            new Provider() { Id = 16, Title = "Lancome" },
            new Provider() { Id = 17, Title = "Lavazza" },
            new Provider() { Id = 18, Title = "Lenovo" },
            new Provider() { Id = 19, Title = "Lipton" }
            );
        modelBuilder.Entity<Product>().HasData(
            new Product() { Id = 1, Title = "Книга \"Гарри Поттер и филосовский камень\"", IdCategory = 1, IdProvider = 14, CostOfOne = 500, Discount = 10 },
            new Product() { Id = 2, Title = "Смартфон iPhone 12 Pro", IdCategory = 2, IdProvider = 1, CostOfOne = 999900, Discount = 5 },
            new Product() { Id = 3, Title = "Ноутбук IdeaPad 3", IdCategory = 2, IdProvider = 18, CostOfOne = 44990, Discount = 15 },
            new Product() { Id = 4, Title = "Кроссовки Gel-Rayano 27", IdCategory = 3, IdProvider = 2, CostOfOne = 12990, Discount = 20 },
            new Product() { Id = 5, Title = "Шоколадная конфета Ferrero Rocher", IdCategory = 4, IdProvider = 5, CostOfOne = 150, Discount = 0 },
            new Product() { Id = 6, Title = "Рюкзак Back To School", IdCategory = 5, IdProvider = 13, CostOfOne = 2990, Discount = 10 },
            new Product() { Id = 7, Title = "Кофе в зернах \"Arabica\"", IdCategory = 4, IdProvider = 17, CostOfOne = 700, Discount = 0 },
            new Product() { Id = 8, Title = "Стиральная машина WM 1080", IdCategory = 6, IdProvider = 9, CostOfOne = 29990, Discount = 7 },
            new Product() { Id = 9, Title = "Шампунь \"Elseve\" для волос", IdCategory = 7, IdProvider = 10, CostOfOne = 300, Discount = 8 },
            new Product() { Id = 10, Title = "Ноутбук MAckBook air", IdCategory = 2, IdProvider = 1, CostOfOne = 89990, Discount = 5 },
            new Product() { Id = 11, Title = "Парфюм \"La Vie Est Belle\"", IdCategory = 8, IdProvider = 16, CostOfOne = 7900, Discount = 12 },
            new Product() { Id = 12, Title = "Керамическая сковорода \"Titanium\"", IdCategory = 9, IdProvider = 12, CostOfOne = 1590, Discount = 20 },
            new Product() { Id = 13, Title = "Набор фломастеров \"Capitan\"", IdCategory = 10, IdProvider = 8, CostOfOne = 490, Discount = 0 },
            new Product() { Id = 14, Title = "Чай \"Golden Tea\"", IdCategory = 4, IdProvider = 19, CostOfOne = 250, Discount = 15 },
            new Product() { Id = 15, Title = "Монитор UltraSharp", IdCategory = 11, IdProvider = 15, CostOfOne = 33990, Discount = 10 },
            new Product() { Id = 16, Title = "Блендер UltraBlend", IdCategory = 12, IdProvider = 11, CostOfOne = 5990, Discount = 0 },
            new Product() { Id = 17, Title = "Маршрутизатор RT-AC86U", IdCategory = 11, IdProvider = 3, CostOfOne = 16490, Discount = 5 },
            new Product() { Id = 18, Title = "Колонки Xtreme 3", IdCategory = 13, IdProvider = 7, CostOfOne = 14990, Discount = 10 },
            new Product() { Id = 19, Title = "Гель для душа \"Cool Water\"", IdCategory = 8, IdProvider = 4, CostOfOne = 590, Discount = 0 },
            new Product() { Id = 20, Title = "Лампа настольная \"Ella\"", IdCategory = 14, IdProvider = 6, CostOfOne = 1590, Discount = 15 }
            );
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
