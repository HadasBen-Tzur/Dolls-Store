using System;
using Ent;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DL
{
    public partial class AmericanDolllContext : DbContext
    {
        public AmericanDolllContext()
        {
        }

        public AmericanDolllContext(DbContextOptions<AmericanDolllContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<OrdersItem> OrdersItem { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Rating> Rating { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=LAPTOP-OON8DCLU;Database=AmericanDolll;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categories>(entity =>
            {
                entity.HasKey(e => e.CategoryId)
                    .HasName("PK__Categori__6DB38D6EB0E8AD7D");

                entity.Property(e => e.CategoryId).HasColumnName("Category_Id");

                entity.Property(e => e.CategoryName)
                    .HasColumnName("Category_Name")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__Orders__F1E4607BF3D4A761");

                entity.Property(e => e.OrderId).HasColumnName("Order_Id");

                entity.Property(e => e.OrderDate)
                    .HasColumnName("Order_Date")
                    .HasMaxLength(50);

                entity.Property(e => e.OrderSum)
                    .HasColumnName("Order_Sum")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("User_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("fk_Orders_User_Id");
            });

            modelBuilder.Entity<OrdersItem>(entity =>
            {
                entity.HasKey(e => e.OrderItemId)
                    .HasName("PK__Orders_I__2F3022022E68CC96");

                entity.ToTable("Orders_Item");

                entity.Property(e => e.OrderItemId).HasColumnName("OrderItem_Id");

                entity.Property(e => e.OrderId).HasColumnName("Order_Id");

                entity.Property(e => e.ProductId).HasColumnName("Product_id");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrdersItem)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("fk_Orders_Order_Id");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrdersItem)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("fk_Orders_Product_Id");
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("PK__Products__9833FF92C25B082C");

                entity.Property(e => e.ProductId).HasColumnName("Product_id");

                entity.Property(e => e.CategoryId).HasColumnName("Category_Id");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ImageName)
                    .HasColumnName("Image_name")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ProductName)
                    .HasColumnName("Product_name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__Products__Catego__267ABA7A");
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.ToTable("RATING");

                entity.Property(e => e.RatingId).HasColumnName("RATING_ID");

                entity.Property(e => e.Host)
                    .HasColumnName("HOST")
                    .HasMaxLength(50);

                entity.Property(e => e.Method)
                    .HasColumnName("METHOD")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Path)
                    .HasColumnName("PATH")
                    .HasMaxLength(50);

                entity.Property(e => e.RecordDate)
                    .HasColumnName("Record_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Referer)
                    .HasColumnName("REFERER")
                    .HasMaxLength(100);

                entity.Property(e => e.UserAgent).HasColumnName("USER_AGENT");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__Users__206A9DF82E287CFA");

                entity.Property(e => e.UserId).HasColumnName("User_id");

                entity.Property(e => e.EMail)
                    .HasColumnName("eMail")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasColumnName("User_Name")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
