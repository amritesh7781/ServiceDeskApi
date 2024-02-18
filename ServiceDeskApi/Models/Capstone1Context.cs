using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ServiceDeskApi.Models;

public partial class Capstone1Context : DbContext
{
    public Capstone1Context()
    {
    }

    public Capstone1Context(DbContextOptions<Capstone1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<DepartmentTable> DepartmentTables { get; set; }

    public virtual DbSet<GroupTable> GroupTables { get; set; }

    public virtual DbSet<RoleTable> RoleTables { get; set; }

    public virtual DbSet<StatusTable> StatusTables { get; set; }

    public virtual DbSet<TicketTable> TicketTables { get; set; }

    public virtual DbSet<UserTable> UserTables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=DESKTOP-CC0P366\\SQLEXPRESS;Initial Catalog=Capstone1;Integrated Security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DepartmentTable>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK__Departme__B2079BCDF713BD75");

            entity.ToTable("DepartmentTable");

            entity.Property(e => e.DepartmentId)
                .ValueGeneratedNever()
                .HasColumnName("DepartmentID");
            entity.Property(e => e.DepartmentName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<GroupTable>(entity =>
        {
            entity.HasKey(e => e.GroupId).HasName("PK__GroupTab__149AF30A05479DA3");

            entity.ToTable("GroupTable");

            entity.Property(e => e.GroupId)
                .ValueGeneratedNever()
                .HasColumnName("GroupID");
            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.GroupName)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Department).WithMany(p => p.GroupTables)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK__GroupTabl__Depar__4D94879B");
        });

        modelBuilder.Entity<RoleTable>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__RoleTabl__8AFACE3A30AC78BB");

            entity.ToTable("RoleTable");

            entity.Property(e => e.RoleId)
                .ValueGeneratedNever()
                .HasColumnName("RoleID");
            entity.Property(e => e.RoleName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<StatusTable>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PK__StatusTa__C8EE204328B3CB65");

            entity.ToTable("StatusTable");

            entity.Property(e => e.StatusId)
                .ValueGeneratedNever()
                .HasColumnName("StatusID");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TicketTable>(entity =>
        {
            entity.HasKey(e => e.TicketId).HasName("PK__TicketTa__712CC627E022000C");

            entity.ToTable("TicketTable");

            entity.Property(e => e.TicketId)
                .ValueGeneratedNever()
                .HasColumnName("TicketID");
            entity.Property(e => e.AssignedToUserId).HasColumnName("AssignedToUserID");
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.CreatorUserId).HasColumnName("CreatorUserID");
            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.GroupId).HasColumnName("GroupID");
            entity.Property(e => e.StatusId).HasColumnName("StatusID");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.AssignedToUser).WithMany(p => p.TicketTableAssignedToUsers)
                .HasForeignKey(d => d.AssignedToUserId)
                .HasConstraintName("FK__TicketTab__Assig__5812160E");

            entity.HasOne(d => d.CreatorUser).WithMany(p => p.TicketTableCreatorUsers)
                .HasForeignKey(d => d.CreatorUserId)
                .HasConstraintName("FK__TicketTab__Creat__571DF1D5");

            entity.HasOne(d => d.Department).WithMany(p => p.TicketTables)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK__TicketTab__Depar__59063A47");

            entity.HasOne(d => d.Group).WithMany(p => p.TicketTables)
                .HasForeignKey(d => d.GroupId)
                .HasConstraintName("FK__TicketTab__Group__59FA5E80");

            entity.HasOne(d => d.Status).WithMany(p => p.TicketTables)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("FK__TicketTab__Statu__5AEE82B9");
        });

        modelBuilder.Entity<UserTable>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__UserTabl__1788CCACDCC9BD9B");

            entity.ToTable("UserTable");

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("UserID");
            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.GroupId).HasColumnName("GroupID");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Department).WithMany(p => p.UserTables)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK__UserTable__Depar__534D60F1");

            entity.HasOne(d => d.Group).WithMany(p => p.UserTables)
                .HasForeignKey(d => d.GroupId)
                .HasConstraintName("FK__UserTable__Group__5441852A");

            entity.HasOne(d => d.Role).WithMany(p => p.UserTables)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__UserTable__RoleI__52593CB8");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
