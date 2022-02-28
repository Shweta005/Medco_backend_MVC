using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Medco_backend.Models;

#nullable disable

namespace MedcoDBcontext
{
    public partial class MedcoDBContext : DbContext
    {
        public MedcoDBContext()
        {
        }

        public MedcoDBContext(DbContextOptions<MedcoDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Coupen> Coupens { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("host=localhost;database=MedcoDB;user id=postgres;password=root@123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Catid)
                    .HasName("categories_pkey");

                entity.ToTable("categories");

                entity.Property(e => e.Catid).HasColumnName("catid");

                entity.Property(e => e.Catname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("catname")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Coupen>(entity =>
            {
                entity.HasKey(e => e.Cid)
                    .HasName("coupen_pkey");

                entity.ToTable("coupen");

                entity.Property(e => e.Cid).HasColumnName("cid");

                entity.Property(e => e.Appliesto).HasColumnName("appliesto");

                entity.Property(e => e.Availability).HasColumnName("availability");

                entity.Property(e => e.Closeddate)
                    .HasColumnType("date")
                    .HasColumnName("closeddate");

                entity.Property(e => e.Coupencode)
                    .HasMaxLength(50)
                    .HasColumnName("coupencode")
                    .IsFixedLength(true);

                entity.Property(e => e.Coupenname)
                    .HasMaxLength(50)
                    .HasColumnName("coupenname")
                    .IsFixedLength(true);

                entity.Property(e => e.Createddate)
                    .HasColumnType("date")
                    .HasColumnName("createddate");

                entity.Property(e => e.Discount).HasColumnName("discount");

                entity.Property(e => e.Expirydate)
                    .HasColumnType("date")
                    .HasColumnName("expirydate");

                entity.HasOne(d => d.AppliestoNavigation)
                    .WithMany(p => p.Coupens)
                    .HasForeignKey(d => d.Appliesto)
                    .HasConstraintName("coupen_appliesto_fkey");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.Oid)
                    .HasName("orders_pkey");

                entity.ToTable("orders");

                entity.Property(e => e.Oid)
                    .ValueGeneratedNever()
                    .HasColumnName("oid");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .HasColumnName("address")
                    .IsFixedLength(true);

                entity.Property(e => e.Coupen)
                    .HasMaxLength(50)
                    .HasColumnName("coupen")
                    .IsFixedLength(true);

                entity.Property(e => e.Deliverydate)
                    .HasColumnType("date")
                    .HasColumnName("deliverydate");

                entity.Property(e => e.Ordereddate)
                    .HasColumnType("date")
                    .HasColumnName("ordereddate");

                entity.Property(e => e.Orderstatus)
                    .HasMaxLength(50)
                    .HasColumnName("orderstatus")
                    .HasDefaultValueSql("'Order Placed'::bpchar")
                    .IsFixedLength(true);

                entity.Property(e => e.Pid).HasColumnName("pid");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Totalprice).HasColumnName("totalprice");

                entity.Property(e => e.Uid).HasColumnName("uid");

                entity.HasOne(d => d.UidNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.Uid)
                    .HasConstraintName("orders_uid_fkey");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Pid)
                    .HasName("products_pkey");

                entity.ToTable("products");

                entity.Property(e => e.Pid).HasColumnName("pid");

                entity.Property(e => e.Catid).HasColumnName("catid");

                entity.Property(e => e.Catname)
                    .HasMaxLength(50)
                    .HasColumnName("catname")
                    .IsFixedLength(true);

                entity.Property(e => e.Imgurl)
                    .HasColumnType("character varying")
                    .HasColumnName("imgurl");

                entity.Property(e => e.Mfgname)
                    .HasColumnType("character varying")
                    .HasColumnName("mfgname");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Productdesc)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("productdesc");

                entity.Property(e => e.Productname)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("productname");

                entity.Property(e => e.Quantity).HasColumnName("quantity");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Uid)
                    .HasName("users_pkey");

                entity.ToTable("users");

                entity.Property(e => e.Uid).HasColumnName("uid");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .HasColumnName("address")
                    .IsFixedLength(true);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("email")
                    .IsFixedLength(true);

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("firstname")
                    .IsFixedLength(true);

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("lastname")
                    .IsFixedLength(true);

                entity.Property(e => e.Mobileno).HasColumnName("mobileno");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("password");

                entity.Property(e => e.Role)
                    .HasMaxLength(20)
                    .HasColumnName("role")
                    .IsFixedLength(true);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
