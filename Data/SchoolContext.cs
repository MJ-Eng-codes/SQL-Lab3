using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SQL_Lab3.Models;

namespace SQL_Lab3.Data;

public partial class SchoolContext : DbContext
{
    public SchoolContext()
    {
    }

    public SchoolContext(DbContextOptions<SchoolContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ClassT> ClassTs { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Enrollment> Enrollments { get; set; }

    public virtual DbSet<Grade> Grades { get; set; }

    public virtual DbSet<Result> Results { get; set; }

    public virtual DbSet<Staff> Staffs { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=School;Integrated Security=True;Encrypt=True;Trust Server Certificate=True;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ClassT>(entity =>
        {
            entity.HasKey(e => e.ClassId).HasName("PK__ClassTs__CB1927A0B2D343E3");

            entity.Property(e => e.ClassId)
                .ValueGeneratedNever()
                .HasColumnName("ClassID");
            entity.Property(e => e.ClassName).HasMaxLength(30);
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("PK__Courses__C92D7187DBED4F61");

            entity.Property(e => e.CourseId).HasColumnName("CourseID");
            entity.Property(e => e.CourseName).HasMaxLength(20);
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK__Departme__B2079BCD0EEA090E");

            entity.Property(e => e.DepartmentId)
                .ValueGeneratedOnAdd()
                .HasColumnName("DepartmentID");
            entity.Property(e => e.DepartmentName).HasMaxLength(20);
        });

        modelBuilder.Entity<Enrollment>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.FkCourseId).HasColumnName("FkCourseID");
            entity.Property(e => e.FkStudentId).HasColumnName("FkStudentID");

            entity.HasOne(d => d.FkCourse).WithMany()
                .HasForeignKey(d => d.FkCourseId)
                .HasConstraintName("FK__Enrollmen__FkCou__32E0915F");

            entity.HasOne(d => d.FkStudent).WithMany()
                .HasForeignKey(d => d.FkStudentId)
                .HasConstraintName("FK__Enrollmen__FkStu__31EC6D26");
        });

        modelBuilder.Entity<Grade>(entity =>
        {
            entity.HasKey(e => e.Grade1).HasName("PK__Grades__DF0ADB7B15A1A349");

            entity.Property(e => e.Grade1)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Grade");
        });

        modelBuilder.Entity<Result>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.FkCourseId).HasColumnName("FkCourseID");
            entity.Property(e => e.FkGrade)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.FkStaffId).HasColumnName("FkStaffID");
            entity.Property(e => e.FkStudentId).HasColumnName("FkStudentID");

            entity.HasOne(d => d.FkCourse).WithMany()
                .HasForeignKey(d => d.FkCourseId)
                .HasConstraintName("FK__Results__FkCours__35BCFE0A");

            entity.HasOne(d => d.FkGradeNavigation).WithMany()
                .HasForeignKey(d => d.FkGrade)
                .HasConstraintName("FK__Results__FkGrade__37A5467C");

            entity.HasOne(d => d.FkStaff).WithMany()
                .HasForeignKey(d => d.FkStaffId)
                .HasConstraintName("FK__Results__FkStaff__36B12243");

            entity.HasOne(d => d.FkStudent).WithMany()
                .HasForeignKey(d => d.FkStudentId)
                .HasConstraintName("FK__Results__FkStude__34C8D9D1");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.StaffId).HasName("PK__Staffs__96D4AAF7FF52490F");

            entity.Property(e => e.StaffId).HasColumnName("StaffID");
            entity.Property(e => e.FirstName).HasMaxLength(30);
            entity.Property(e => e.FkCourseId).HasColumnName("FkCourseID");
            entity.Property(e => e.FkDepartmentId).HasColumnName("FkDepartmentID");
            entity.Property(e => e.LastName).HasMaxLength(40);

            entity.HasOne(d => d.FkCourse).WithMany(p => p.Staff)
                .HasForeignKey(d => d.FkCourseId)
                .HasConstraintName("FK__Staffs__FkCourse__2D27B809");

            entity.HasOne(d => d.FkDepartment).WithMany(p => p.Staff)
                .HasForeignKey(d => d.FkDepartmentId)
                .HasConstraintName("FK__Staffs__FkDepart__2C3393D0");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Students__32C52A79884AAEF5");

            entity.Property(e => e.StudentId).HasColumnName("StudentID");
            entity.Property(e => e.FirstName).HasMaxLength(30);
            entity.Property(e => e.FkClassId).HasColumnName("FkClassID");
            entity.Property(e => e.LastName).HasMaxLength(40);

            entity.HasOne(d => d.FkClass).WithMany(p => p.Students)
                .HasForeignKey(d => d.FkClassId)
                .HasConstraintName("FK__Students__FkClas__300424B4");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
