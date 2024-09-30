using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace VillaManagementSys.Db
{
    public partial class VillaReservationContext : DbContext
    {
        public VillaReservationContext()
        {
        }

        public VillaReservationContext(DbContextOptions<VillaReservationContext> options)
            : base(options)
        {
        }

        public virtual DbSet<City> Cities { get; set; } = null!;
        public virtual DbSet<Province> Provinces { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserRole> UserRoles { get; set; } = null!;
        public virtual DbSet<Villa> Villas { get; set; } = null!;
        public virtual DbSet<ViwVilla> ViwVillas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.\\SDDSAASD;Initial Catalog=VillaReservation;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>(entity =>
            {
                entity.Property(e => e.Latitude).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Longtitude).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.PrefixCode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.Province)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.ProvinceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cities_Province");
            });

            modelBuilder.Entity<Province>(entity =>
            {
                entity.ToTable("Province");

                entity.Property(e => e.Langtitude).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Latitude).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.PrefixCode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Status)
                    .HasMaxLength(15)
                    .HasDefaultValueSql("(N'Active')");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserRoles_Roles");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserRoles_Users");
            });

            modelBuilder.Entity<Villa>(entity =>
            {
                entity.HasIndex(e => e.Capacity, "NonClusteredIndex-20240803-205228");

                entity.HasIndex(e => e.Status, "NonClusteredIndex-status");

                entity.Property(e => e.Address).HasMaxLength(300);

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.Langtitude)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Latitude)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.SpecialTag)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(15)
                    .HasDefaultValueSql("(N'Unreserved')");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Villas)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Villas_Cities1");
            });

            modelBuilder.Entity<ViwVilla>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("viwVillas");

                entity.Property(e => e.Address).HasMaxLength(500);

                entity.Property(e => e.Expr1).HasMaxLength(50);

                entity.Property(e => e.Expr2).HasMaxLength(50);

                entity.Property(e => e.InsertDate).HasColumnType("datetime");

                entity.Property(e => e.Langtitude).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Latitude).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Status).HasMaxLength(15);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
