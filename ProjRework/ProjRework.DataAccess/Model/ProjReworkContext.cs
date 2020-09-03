using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProjRework.DataAccess.Model
{
  public partial class ProjReworkContext : DbContext
  {
    public ProjReworkContext()
    {
    }

    public ProjReworkContext(DbContextOptions<ProjReworkContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customer { get; set; }
    public virtual DbSet<Orderhistory> Orderhistory { get; set; }
    public virtual DbSet<Orderinst> Orderinst { get; set; }
    public virtual DbSet<Product> Product { get; set; }
    public virtual DbSet<Store> Store { get; set; }
    public virtual DbSet<Storeinventory> Storeinventory { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Customer>(entity =>
      {
        entity.HasKey(e => e.Custid)
                  .HasName("customer_pkey");

        entity.ToTable("customer");

        entity.Property(e => e.Custid)
                  .HasColumnName("custid")
                  .UseIdentityAlwaysColumn();

        entity.Property(e => e.Firstname)
                  .IsRequired()
                  .HasColumnName("firstname")
                  .HasMaxLength(50);

        entity.Property(e => e.Lastname)
                  .IsRequired()
                  .HasColumnName("lastname")
                  .HasMaxLength(50);
      });

      modelBuilder.Entity<Orderhistory>(entity =>
      {
        entity.ToTable("orderhistory");

        entity.Property(e => e.Orderhistoryid)
                  .HasColumnName("orderhistoryid")
                  .UseIdentityAlwaysColumn();

        entity.Property(e => e.Orderid).HasColumnName("orderid");

        entity.Property(e => e.Productid).HasColumnName("productid");

        entity.HasOne(d => d.Order)
                  .WithMany(p => p.Orderhistory)
                  .HasForeignKey(d => d.Orderid)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("orderhistory_orderid_fkey");

        entity.HasOne(d => d.Product)
                  .WithMany(p => p.Orderhistory)
                  .HasForeignKey(d => d.Productid)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("orderhistory_productid_fkey");
      });

      modelBuilder.Entity<Orderinst>(entity =>
      {
        entity.HasKey(e => e.Orderid)
                  .HasName("orderinst_pkey");

        entity.ToTable("orderinst");

        entity.Property(e => e.Orderid)
                  .HasColumnName("orderid")
                  .UseIdentityAlwaysColumn();

        entity.Property(e => e.Customerid).HasColumnName("customerid");

        entity.Property(e => e.Orderdate)
                  .HasColumnName("orderdate")
                  .HasColumnType("date");

        entity.Property(e => e.Storeid).HasColumnName("storeid");

        entity.HasOne(d => d.Customer)
                  .WithMany(p => p.Orderinst)
                  .HasForeignKey(d => d.Customerid)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("orderinst_customerid_fkey");

        entity.HasOne(d => d.Store)
                  .WithMany(p => p.Orderinst)
                  .HasForeignKey(d => d.Storeid)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("orderinst_storeid_fkey");
      });

      modelBuilder.Entity<Product>(entity =>
      {
        entity.ToTable("product");

        entity.Property(e => e.Productid)
                  .HasColumnName("productid")
                  .UseIdentityAlwaysColumn();

        entity.Property(e => e.Productdescription)
                  .IsRequired()
                  .HasColumnName("productdescription")
                  .HasMaxLength(50);

        entity.Property(e => e.Productprice)
                  .HasColumnName("productprice")
                  .HasColumnType("numeric(10,2)");
      });

      modelBuilder.Entity<Store>(entity =>
      {
        entity.ToTable("store");

        entity.Property(e => e.Storeid)
                  .HasColumnName("storeid")
                  .UseIdentityAlwaysColumn();

        entity.Property(e => e.Storename)
                  .HasColumnName("storename")
                  .HasMaxLength(50);
      });

      modelBuilder.Entity<Storeinventory>(entity =>
      {
        entity.HasKey(e => e.Storeinvid)
                  .HasName("storeinventory_pkey");

        entity.ToTable("storeinventory");

        entity.Property(e => e.Storeinvid)
                  .HasColumnName("storeinvid")
                  .UseIdentityAlwaysColumn();

        entity.Property(e => e.Productid).HasColumnName("productid");

        entity.Property(e => e.Quantity).HasColumnName("quantity");

        entity.Property(e => e.Storeid).HasColumnName("storeid");

        entity.HasOne(d => d.Product)
                  .WithMany(p => p.Storeinventory)
                  .HasForeignKey(d => d.Productid)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("storeinventory_productid_fkey");

        entity.HasOne(d => d.Store)
                  .WithMany(p => p.Storeinventory)
                  .HasForeignKey(d => d.Storeid)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("storeinventory_storeid_fkey");
      });

      OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
  }
}
