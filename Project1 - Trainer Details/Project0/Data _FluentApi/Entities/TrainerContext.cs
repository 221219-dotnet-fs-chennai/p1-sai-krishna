using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Data__FluentApi.Entities;

public partial class TrainerContext : DbContext
{
    public TrainerContext()
    {
    }

    public TrainerContext(DbContextOptions<TrainerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Achivement> Achivements { get; set; }

    public virtual DbSet<Education> Educations { get; set; }

    public virtual DbSet<Experience> Experiences { get; set; }

    public virtual DbSet<Skill> Skills { get; set; }

    public virtual DbSet<Trainer> Trainers { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=tcp:sai-db-server.database.windows.net,1433;Initial Catalog=Project0;Persist Security Info=False;User ID=saikrishna;Password=Sai123456;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Achivement>(entity =>
        {
            entity.HasKey(e => e.AchivementsId).HasName("PK__Achiveme__EE2FC82933D9AE35");

            entity.Property(e => e.AchivementsId).HasColumnName("Achivements_id");
            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.Title)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.TrainerId).HasColumnName("Trainer_id");

            entity.HasOne(d => d.Trainer).WithMany(p => p.Achivements)
                .HasForeignKey(d => d.TrainerId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Achivements.Trainer_id");
        });

        modelBuilder.Entity<Education>(entity =>
        {
            entity.HasKey(e => e.EducationId).HasName("PK__Educatio__C3E235992D6CF71A");

            entity.ToTable("Education");

            entity.Property(e => e.EducationId).HasColumnName("Education_id");
            entity.Property(e => e.Cgpa)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CGPA");
            entity.Property(e => e.Degree)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.EndDate)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("End_date");
            entity.Property(e => e.InstituteName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Institute_name");
            entity.Property(e => e.StartDate)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("Start_date");
            entity.Property(e => e.TrainerId).HasColumnName("Trainer_id");

            entity.HasOne(d => d.Trainer).WithMany(p => p.Educations)
                .HasForeignKey(d => d.TrainerId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Education.Trainer_id");
        });

        modelBuilder.Entity<Experience>(entity =>
        {
            entity.HasKey(e => e.ExperiencId).HasName("PK__Experien__2A765D34FDDA7458");

            entity.ToTable("Experience");

            entity.Property(e => e.ExperiencId).HasColumnName("Experienc_id");
            entity.Property(e => e.CmpName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Cmp_name");
            entity.Property(e => e.EndDate)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("End_date");
            entity.Property(e => e.Role)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.StartDate)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("Start_date");
            entity.Property(e => e.TrainerId).HasColumnName("Trainer_id");

            entity.HasOne(d => d.Trainer).WithMany(p => p.Experiences)
                .HasForeignKey(d => d.TrainerId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Companies.Trainer_id");
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.HasKey(e => e.SkillId).HasName("PK__Skills__B4AAE688F86FC5FC");

            entity.Property(e => e.SkillId).HasColumnName("Skill_id");
            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.SkillName)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("Skill_name");
            entity.Property(e => e.TrainerId).HasColumnName("Trainer_id");

            entity.HasOne(d => d.Trainer).WithMany(p => p.Skills)
                .HasForeignKey(d => d.TrainerId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Skills.Trainer_id");
        });

        modelBuilder.Entity<Trainer>(entity =>
        {
            entity.HasKey(e => e.TrainerId).HasName("PK__Trainer__8B0DBD6910C16A8D");

            entity.ToTable("Trainer");

            entity.HasIndex(e => e.Email, "UQ__Trainer__A9D105346936B648").IsUnique();

            entity.Property(e => e.TrainerId).HasColumnName("Trainer_id");
            entity.Property(e => e.AboutMe)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("About_me");
            entity.Property(e => e.City)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Phone_no");
            entity.Property(e => e.Pincode)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.State)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
