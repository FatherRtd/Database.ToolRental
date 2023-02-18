using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ToolRental.API.Models;

public partial class ToolrentalContext : DbContext
{
	public ToolrentalContext(DbContextOptions<ToolrentalContext> options)
        : base(options) { }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<RentalOrder> RentalOrders { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("category", tb => tb.HasComment("Категория товара"));

            entity.HasIndex(e => e.ParentId, "parent_id");

            entity.Property(e => e.Id)
                .HasComment("Индекс категории")
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasComment("Название категории")
                .HasColumnName("name");
            entity.Property(e => e.ParentId)
                .HasComment("Индекс родительской категории")
                .HasColumnName("parent_id");

            entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent)
                .HasForeignKey(d => d.ParentId)
                .HasConstraintName("category_ibfk_1");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("product", tb => tb.HasComment("Информация о товаре"));

            entity.HasIndex(e => e.CategoryId, "category_id");

            entity.Property(e => e.Id)
                .HasComment("ID товара")
                .HasColumnName("id");
            entity.Property(e => e.CategoryId)
                .HasComment("Индекс категории")
                .HasColumnName("category_id");
            entity.Property(e => e.Image)
                .HasMaxLength(255)
                .HasComment("Изображение товара")
                .HasColumnName("image");
            entity.Property(e => e.IsInStock)
                .HasComment("Наличие товара")
                .HasColumnName("is_in_stock");
            entity.Property(e => e.LongDescription)
                .HasMaxLength(1024)
                .HasComment("Полное описание")
                .HasColumnName("long_description");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasComment("Наименование товара")
                .HasColumnName("name");
            entity.Property(e => e.RentalPrice)
                .HasComment("Цена аренды")
                .HasColumnName("rental_price");
            entity.Property(e => e.ShortDescription)
                .HasMaxLength(255)
                .HasComment("Краткое описание")
                .HasColumnName("short_description");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("product_ibfk_1");
        });

        modelBuilder.Entity<RentalOrder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("rental_order", tb => tb.HasComment("Информация о заказе"));

            entity.HasIndex(e => e.ProductId, "product_id");

            entity.HasIndex(e => e.UserId, "user_id");

            entity.Property(e => e.Id)
                .HasComment("Индекс заказа")
                .HasColumnName("id");
            entity.Property(e => e.IsDone)
                .HasComment("Заказ завершён")
                .HasColumnName("is_done");
            entity.Property(e => e.OrderDate)
                .HasComment("Дата и время начала аренды")
                .HasColumnType("datetime")
                .HasColumnName("order_date");
            entity.Property(e => e.OrderEndDate)
                .HasComment("Дата и время окончания аренды")
                .HasColumnType("datetime")
                .HasColumnName("order_end_date");
            entity.Property(e => e.ProductId)
                .HasComment("Индекс товара")
                .HasColumnName("product_id");
            entity.Property(e => e.RentalPrice)
                .HasComment("Цена аренды")
                .HasColumnName("rental_price");
            entity.Property(e => e.UserId)
                .HasComment("Индекс пользователя")
                .HasColumnName("user_id");

            entity.HasOne(d => d.Product).WithMany(p => p.RentalOrders)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rental_order_ibfk_1");

            entity.HasOne(d => d.User).WithMany(p => p.RentalOrders)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rental_order_ibfk_2");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("user", tb => tb.HasComment("Информация о пользователе"));

            entity.Property(e => e.Id)
                .HasComment("ID пользователя")
                .HasColumnName("id");
            entity.Property(e => e.Firstname)
                .HasMaxLength(255)
                .HasComment("Имя")
                .HasColumnName("firstname");
            entity.Property(e => e.IsAdmin)
                .HasComment("Является администратором")
                .HasColumnName("is_admin");
            entity.Property(e => e.Lastname)
                .HasMaxLength(255)
                .HasComment("Фамилия")
                .HasColumnName("lastname");
            entity.Property(e => e.Login)
                .HasMaxLength(255)
                .HasComment("Логин")
                .HasColumnName("login");
            entity.Property(e => e.Md5password)
                .HasMaxLength(255)
                .HasComment("Пароль")
                .HasColumnName("md5password");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
