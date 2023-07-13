﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Ass_SWD.DataAccess.Models
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
        public virtual DbSet<staff> staff { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=LAPTOP-G54QJ7QB\\MSSQLSERVER01; database =MyStore;uid=sa;pwd=123;");
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
                    .HasConstraintName("FK__Fee__RecordID__4CA06362");
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
                    .HasConstraintName("FK__Insurance__Patie__4D94879B");
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

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.Partner).HasMaxLength(100);

                entity.Property(e => e.PayedDate).HasColumnType("date");

                entity.Property(e => e.RequiredDate).HasColumnType("date");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Payment__Categor__4E88ABD4");
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
                    .HasConstraintName("FK__Record__PatientI__4AB81AF0");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.Records)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Record__ServiceI__4BAC3F29");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.ToTable("Service");

                entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

                entity.Property(e => e.Fee).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Type).HasMaxLength(40);
            });

            modelBuilder.Entity<staff>(entity =>
            {
                entity.ToTable("Staff");

                entity.HasIndex(e => e.UserName, "UQ__Staff__C9F28456CE3A5518")
                    .IsUnique();

                entity.Property(e => e.StaffId).HasColumnName("StaffID");

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