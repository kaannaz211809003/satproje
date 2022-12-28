using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PersonelApp.Models
{
    public partial class PersonelContext : DbContext
    {
        public PersonelContext()
        {
        }

        public PersonelContext(DbContextOptions<PersonelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Personel> Personels { get; set; }
        public virtual DbSet<PersonelCategory> PersonelCategories { get; set; }
        public virtual DbSet<PersonelPermission> PersonelPermissions { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Seizure> Seizures { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("data source=.;initial catalog=PersonelDb;persist security info=True; Integrated Security=true;multipleactiveresultsets=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Turkish_CI_AS");

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.Property(e => e.PaymentAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PaymentDescription).HasMaxLength(50);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Payments_Personel");
            });

            modelBuilder.Entity<Personel>(entity =>
            {
                entity.ToTable("Personel");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Gsm).HasMaxLength(12);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.PermissionDays).HasMaxLength(50);

                entity.Property(e => e.Surname).HasMaxLength(50);

                entity.Property(e => e.Tckn)
                    .HasMaxLength(11)
                    .HasColumnName("TCKN");

                entity.Property(e => e.Title).HasMaxLength(50);

                entity.Property(e => e.Username).HasMaxLength(50);
            });

            modelBuilder.Entity<PersonelCategory>(entity =>
            {
                entity.ToTable("PersonelCategory");

                entity.Property(e => e.CategoryName).HasMaxLength(50);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PersonelCategories)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_PersonelCategory_Personel");
            });

            modelBuilder.Entity<PersonelPermission>(entity =>
            {
                entity.ToTable("PersonelPermission");
                entity.Property(e => e.Description).HasMaxLength(150);
                entity.HasOne(d => d.User)
                    .WithMany(p => p.PersonelPermissions)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_PersonelPermission_Personel");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.RoleName).HasMaxLength(50);
            });

            modelBuilder.Entity<Seizure>(entity =>
            {
                entity.Property(e => e.SeizuresDate)
                    .HasColumnType("datetime")
                    .HasColumnName("seizuresDate");

                entity.Property(e => e.SeizuresEndDate).HasColumnName("seizuresEndDate");
                entity.Property(e => e.Location).HasMaxLength(100);
                entity.Property(e => e.SeizuresStartDate).HasColumnName("seizuresStartDate");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Seizures)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Seizures_Personel");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_UserRoles_Role");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_UserRoles_Personel");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
