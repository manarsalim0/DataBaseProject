using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ResourcesBankNew.Models
{
    public partial class ResourcesBankContext : DbContext
    {
        public ResourcesBankContext()
        {
        }

        public ResourcesBankContext(DbContextOptions<ResourcesBankContext> options)
            : base(options)
        {
        }

        public  DbSet<Course> Courses { get; set; }
        public  DbSet<EngFaculty> EngFaculties { get; set; }
        public  DbSet<Level> Levels { get; set; }
        public  DbSet<Major> Majors { get; set; }
        public  DbSet<Material> Materials { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-B0KDJC5\\SQLEXPRESS;Database=ResourcesBank;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Course");

                entity.Property(e => e.CourseId)
                    .ValueGeneratedNever()
                    .HasColumnName("Course_Id");

                entity.Property(e => e.CourseName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Course_Name");

                entity.Property(e => e.FolderLink)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("Folder_Link");

                entity.Property(e => e.LevelId).HasColumnName("Level_Id");

                entity.HasOne(d => d.Level)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.LevelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Course_Level");
            });

            modelBuilder.Entity<EngFaculty>(entity =>
            {
                entity.HasKey(e => e.FacultyId);

                entity.ToTable("Eng_Faculty");

                entity.Property(e => e.FacultyId)
                    .ValueGeneratedNever()
                    .HasColumnName("Faculty_Id");

                entity.Property(e => e.FacultyName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Faculty_Name");
            });

            modelBuilder.Entity<Level>(entity =>
            {
                entity.ToTable("Level");

                entity.Property(e => e.LevelId)
                    .ValueGeneratedNever()
                    .HasColumnName("Level_Id");

                entity.Property(e => e.LevelNum).HasColumnName("Level_Num");

                entity.Property(e => e.MajorId).HasColumnName("Major_Id");

                entity.Property(e => e.RootLink)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("Root_Link");

                entity.Property(e => e.TakenYear).HasColumnName("Taken_Year");

                entity.Property(e => e.TermNum).HasColumnName("Term_Num");

                entity.HasOne(d => d.Major)
                    .WithMany(p => p.Levels)
                    .HasForeignKey(d => d.MajorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Level_Major");
            });

            modelBuilder.Entity<Major>(entity =>
            {
                entity.ToTable("Major");

                entity.Property(e => e.MajorId)
                    .ValueGeneratedNever()
                    .HasColumnName("Major_Id");

                entity.Property(e => e.FacultyId).HasColumnName("Faculty_Id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.RootLink)
                    .HasMaxLength(300)
                    .HasColumnName("Root_Link");

                entity.HasOne(d => d.Faculty)
                    .WithMany(p => p.Majors)
                    .HasForeignKey(d => d.FacultyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Major_Eng_Faculty");
            });

            modelBuilder.Entity<Material>(entity =>
            {
                entity.ToTable("Material");

                entity.Property(e => e.MaterialId)
                    .ValueGeneratedNever()
                    .HasColumnName("Material_Id");

                entity.Property(e => e.CourseId).HasColumnName("Course_Id");

                entity.Property(e => e.Link)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Materials)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Material_Course");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
