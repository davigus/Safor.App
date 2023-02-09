using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Safor.DataModel.Model;

public partial class SaforContext : DbContext
{
    public SaforContext()
    {
    }

    public SaforContext(DbContextOptions<SaforContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\;Database=Safor;User Id=sa;Password=peterPan86!;Trusted_Connection=False;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Customer__3214EC0701904877");

            entity.ToTable("Customers", "MasterData");

            entity.Property(e => e.CustomerName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CustomerVatnumber)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("CustomerVATNumber");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Orders__3214EC07B5BE2DB3");

            entity.ToTable("Orders", "MasterData");

            entity.Property(e => e.DueDate).HasColumnType("date");
            entity.Property(e => e.OrderCode)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.OrderDate).HasColumnType("date");
            entity.Property(e => e.OrderName)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FkMasterDataOrdersMasterDataCustomers");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OrderDet__3214EC07C452D939");

            entity.ToTable("OrderDetails", "MasterData");

            entity.Property(e => e.Quantity).HasColumnType("numeric(10, 2)");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FkMasterDataOrderDetailsMasterDataOrders");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FkMasterDataOrderDetailsMasterDataProducts");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Products__3214EC074102FB40");

            entity.ToTable("Products", "MasterData");

            entity.Property(e => e.ProductDescription)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ProductName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ProductionCode)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ProductionCodeRevision)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.ProductionFileName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ProductionRevision)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
