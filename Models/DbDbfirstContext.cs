using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplication4.Models;

public partial class DbDbfirstContext : DbContext
{
    public DbDbfirstContext()
    {
    }

    public DbDbfirstContext(DbContextOptions<DbDbfirstContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Khoa> Khoas { get; set; }

    public virtual DbSet<Lop> Lops { get; set; }

    public virtual DbSet<SinhVien> SinhViens { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=dbDBFirst;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Khoa>(entity =>
        {
            entity.HasKey(e => e.MaKhoa).HasName("PK__Khoa__65390405D2E500C4");

            entity.ToTable("Khoa");

            entity.Property(e => e.MaKhoa)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.TenKhoa).HasMaxLength(100);
        });

        modelBuilder.Entity<Lop>(entity =>
        {
            entity.HasKey(e => e.MaLop).HasName("PK__Lop__3B98D273B8BB03B0");

            entity.ToTable("Lop");

            entity.Property(e => e.MaLop)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.Khoa)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.Nganh).HasMaxLength(100);

            entity.HasOne(d => d.KhoaNavigation).WithMany(p => p.Lops)
                .HasForeignKey(d => d.Khoa)
                .HasConstraintName("FK__Lop__Khoa__398D8EEE");
        });

        modelBuilder.Entity<SinhVien>(entity =>
        {
            entity.HasKey(e => e.MaSinhVien).HasName("PK__SinhVien__939AE7756F413758");

            entity.ToTable("SinhVien");

            entity.Property(e => e.MaSinhVien)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.HoTen).HasMaxLength(100);
            entity.Property(e => e.Lop)
                .HasMaxLength(5)
                .IsUnicode(false);

            entity.HasOne(d => d.LopNavigation).WithMany(p => p.SinhViens)
                .HasForeignKey(d => d.Lop)
                .HasConstraintName("FK__SinhVien__Lop__3C69FB99");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
