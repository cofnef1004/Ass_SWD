using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Ass_SWD.Models
{
    public partial class MyStoreContext : DbContext
    {
        public MyStoreContext()
        {
        }

        public MyStoreContext(DbContextOptions<MyStoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Fee> Fees { get; set; } = null!;
        public virtual DbSet<Insurance> Insurances { get; set; } = null!;
        public virtual DbSet<Patient> Patients { get; set; } = null!;
        public virtual DbSet<Payment> Payments { get; set; } = null!;
        public virtual DbSet<Record> Records { get; set; } = null!;
        public virtual DbSet<Service> Services { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var conf = new ConfigurationBuilder()
                  .SetBasePath(Directory.GetCurrentDirectory())
                  .AddJsonFile("appsettings.json").Build();
                optionsBuilder.UseSqlServer(conf.GetConnectionString("MyStore"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CategoryName).HasMaxLength(20);

                entity.Property(e => e.Description).HasMaxLength(100);
            });


            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Employee");

                entity.HasIndex(e => e.UserName, "UQ__Employee__C9F28456166F020E")
                    .IsUnique();

                entity.Property(e => e.Address).HasMaxLength(100);

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("DOB");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.FullName).HasMaxLength(50);

                entity.Property(e => e.Gender).HasMaxLength(10);

                entity.Property(e => e.NumberId)
                    .HasMaxLength(15)
                    .HasColumnName("NumberID");

                entity.Property(e => e.Password).HasMaxLength(20);

                entity.Property(e => e.Phone).HasMaxLength(12);

                entity.Property(e => e.Role).HasMaxLength(40);

                entity.Property(e => e.UserName).HasMaxLength(15);
            });


            modelBuilder.Entity<Fee>(entity =>
            {
                entity.ToTable("Fee");

                entity.Property(e => e.FeeId).HasColumnName("FeeID");

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Method).HasMaxLength(20);

                entity.Property(e => e.PaiedDate).HasColumnType("date");

                entity.Property(e => e.PaymentDate).HasColumnType("date");

                entity.Property(e => e.RecordId).HasColumnName("RecordID");

                entity.HasOne(d => d.Record)
                    .WithMany(p => p.Fees)
                    .HasForeignKey(d => d.RecordId)
                    .OnDelete(DeleteBehavior.ClientSetNull)

                    .HasConstraintName("FK__Fee__RecordID__4CA06362")
                    .HasConstraintName("FK__Fee__RecordID__32E0915F");

            });

            modelBuilder.Entity<Insurance>(entity =>
            {
                entity.ToTable("Insurance");

                entity.Property(e => e.InsuranceId).HasColumnName("InsuranceID");

                entity.Property(e => e.Number).HasMaxLength(10);

                entity.Property(e => e.PatientId).HasColumnName("PatientID");

                entity.Property(e => e.Percent).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Supplier).HasMaxLength(100);

                entity.Property(e => e.Type).HasMaxLength(50);

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Insurances)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)

                    .HasConstraintName("FK__Insurance__Patie__4D94879B")

                    .HasConstraintName("FK__Insurance__Patie__33D4B598");

            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.ToTable("Patient");

                entity.Property(e => e.PatientId).HasColumnName("PatientID");

                entity.Property(e => e.Address).HasMaxLength(100);

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("DOB");

                entity.Property(e => e.FullName).HasMaxLength(50);

                entity.Property(e => e.Gender).HasMaxLength(10);

                entity.Property(e => e.NumberId)
                    .HasMaxLength(15)
                    .HasColumnName("NumberID");

                entity.Property(e => e.Phone).HasMaxLength(12);
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("Payment");

                entity.Property(e => e.PaymentId).HasColumnName("PaymentID");

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.BillingInformation).HasMaxLength(100);

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.PayedDate).HasColumnType("date");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)

                    .HasConstraintName("FK__Payment__Categor__4E88ABD4")

                    .HasConstraintName("FK__Payment__Categor__34C8D9D1");

            });

            modelBuilder.Entity<Record>(entity =>
            {
                entity.ToTable("Record");

                entity.Property(e => e.RecordId).HasColumnName("RecordID");

                entity.Property(e => e.Diagnosis)
                    .HasColumnType("text")
                    .HasColumnName("diagnosis");

                entity.Property(e => e.ImagingResult)
                    .HasColumnType("text")
                    .HasColumnName("imaging_result");

                entity.Property(e => e.PatientId).HasColumnName("PatientID");

                entity.Property(e => e.Prescription)
                    .HasColumnType("text")
                    .HasColumnName("prescription");

                entity.Property(e => e.RecordDate).HasColumnType("date");

                entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

                entity.Property(e => e.TestResult)
                    .HasColumnType("text")
                    .HasColumnName("test_result");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Records)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)

                    .HasConstraintName("FK__Record__PatientI__4AB81AF0")

                    .HasConstraintName("FK__Record__PatientI__35BCFE0A");


                entity.HasOne(d => d.Service)
                    .WithMany(p => p.Records)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)

                    .HasConstraintName("FK__Record__ServiceI__4BAC3F29")

                    .HasConstraintName("FK__Record__ServiceI__36B12243");

            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.ToTable("Service");

                entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

                entity.Property(e => e.Fee).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Type).HasMaxLength(40);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.HasIndex(e => e.UserName, "UQ__User__C9F284568A929957")
                    .IsUnique();

                entity.Property(e => e.Address).HasMaxLength(100);

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("DOB");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.FullName).HasMaxLength(50);

                entity.Property(e => e.Gender).HasMaxLength(10);

                entity.Property(e => e.NumberId)
                    .HasMaxLength(15)
                    .HasColumnName("NumberID");

                entity.Property(e => e.Password).HasMaxLength(20);

                entity.Property(e => e.Phone).HasMaxLength(12);

                entity.Property(e => e.Role).HasMaxLength(40);

                entity.Property(e => e.UserName).HasMaxLength(15);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
