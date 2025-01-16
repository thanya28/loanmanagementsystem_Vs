using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace loanmgsystem.Model;

public partial class LoanManagementSystemContext : DbContext
{
    public LoanManagementSystemContext()
    {
    }

    public LoanManagementSystemContext(DbContextOptions<LoanManagementSystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<BackgroundVerification> BackgroundVerifications { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<Help> Helps { get; set; }

    public virtual DbSet<Loan> Loans { get; set; }

    public virtual DbSet<LoanOfficer> LoanOfficers { get; set; }

   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.AdminId).HasName("PK__Admins__719FE4887A331B6C");

            entity.HasIndex(e => e.Username, "UQ__Admins__536C85E491338EB6").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Admins__A9D10534A85825CC").IsUnique();

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<BackgroundVerification>(entity =>
        {
            entity.HasKey(e => e.VerificationId).HasName("PK__Backgrou__306D49070B968FBE");

            entity.ToTable("BackgroundVerification");

            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("('Pending')");

            entity.HasOne(d => d.Loan).WithMany(p => p.BackgroundVerifications)
                .HasForeignKey(d => d.LoanId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Backgroun__LoanI__4F7CD00D");

            entity.HasOne(d => d.Officer).WithMany(p => p.BackgroundVerifications)
                .HasForeignKey(d => d.OfficerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Backgroun__Offic__5070F446");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64D8108650A7");

            entity.HasIndex(e => e.Username, "UQ__Customer__536C85E45948DC30").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Customer__A9D105341B3D6158").IsUnique();

            entity.Property(e => e.ContactNumber)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FullName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("('Pending')");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.FeedbackId).HasName("PK__Feedback__6A4BEDD6D0C7B6BD");

            entity.ToTable("Feedback");

            entity.HasOne(d => d.Customer).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Feedback__Custom__49C3F6B7");
        });

        modelBuilder.Entity<Help>(entity =>
        {
            entity.HasKey(e => e.HelpId).HasName("PK__Help__90E322CEBD60E89A");

            entity.ToTable("Help");

            entity.Property(e => e.Query).HasMaxLength(255);
        });

        modelBuilder.Entity<Loan>(entity =>
        {
            entity.HasKey(e => e.LoanId).HasName("PK__Loans__4F5AD457970BF2A2");

            entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.InterestRate).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.LoanType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("('Pending')");

            entity.HasOne(d => d.AssignedOfficer).WithMany(p => p.Loans)
                .HasForeignKey(d => d.AssignedOfficerId)
                .HasConstraintName("FK__Loans__AssignedO__46E78A0C");

            entity.HasOne(d => d.Customer).WithMany(p => p.Loans)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Loans__CustomerI__45F365D3");
        });

        modelBuilder.Entity<LoanOfficer>(entity =>
        {
            entity.HasKey(e => e.OfficerId).HasName("PK__LoanOffi__2E65577A03EAA127");

            entity.HasIndex(e => e.Username, "UQ__LoanOffi__536C85E4D1C7B54C").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__LoanOffi__A9D10534C59E7DA3").IsUnique();

            entity.Property(e => e.ContactNumber)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FullName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("('Pending')");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
