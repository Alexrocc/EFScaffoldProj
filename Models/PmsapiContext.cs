using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace EFScaffoldProj.Models;

public partial class PmsapiContext : DbContext
{
    public PmsapiContext()
    {
    }

    public PmsapiContext(DbContextOptions<PmsapiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<ProjectCategory> ProjectCategories { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Task> Tasks { get; set; }

    public virtual DbSet<TaskAttachment> TaskAttachments { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        => optionsBuilder.UseMySql("server=localhost;port=3306;database=pmsapi;user=root;password=mariam", Microsoft.EntityFrameworkCore.ServerVersion.Parse("11.4.2-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("latin1_swedish_ci")
            .HasCharSet("latin1");

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("projects");

            entity.HasIndex(e => e.ProjectCategoriesId, "project_categories_id");

            entity.HasIndex(e => e.UsersManagerId, "users_manager_id");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.ProjectCategoriesId)
                .HasColumnType("int(11)")
                .HasColumnName("project_categories_id");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
            entity.Property(e => e.UsersManagerId)
                .HasColumnType("int(11)")
                .HasColumnName("users_manager_id");

            entity.HasOne(d => d.ProjectCategories).WithMany(p => p.Projects)
                .HasForeignKey(d => d.ProjectCategoriesId)
                .HasConstraintName("projects_ibfk_1");

            entity.HasOne(d => d.UsersManager).WithMany(p => p.Projects)
                .HasForeignKey(d => d.UsersManagerId)
                .HasConstraintName("projects_ibfk_2");
        });

        modelBuilder.Entity<ProjectCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("project_categories");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("roles");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tasks");

            entity.HasIndex(e => e.ProjectsId, "projects_id");

            entity.HasIndex(e => e.UsersId, "users_id");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.DueDate).HasColumnName("due_date");
            entity.Property(e => e.Priority)
                .HasMaxLength(50)
                .HasColumnName("priority");
            entity.Property(e => e.ProjectsId)
                .HasColumnType("int(11)")
                .HasColumnName("projects_id");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .HasColumnName("title");
            entity.Property(e => e.UsersId)
                .HasColumnType("int(11)")
                .HasColumnName("users_id");

            entity.HasOne(d => d.Projects).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.ProjectsId)
                .HasConstraintName("tasks_ibfk_1");

            entity.HasOne(d => d.Users).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.UsersId)
                .HasConstraintName("tasks_ibfk_2");
        });

        modelBuilder.Entity<TaskAttachment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("task_attachments");

            entity.HasIndex(e => e.TasksId, "tasks_id");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.FileData)
                .HasColumnType("blob")
                .HasColumnName("file_data");
            entity.Property(e => e.FileName)
                .HasMaxLength(255)
                .HasColumnName("file_name");
            entity.Property(e => e.TasksId)
                .HasColumnType("int(11)")
                .HasColumnName("tasks_id");

            entity.HasOne(d => d.Tasks).WithMany(p => p.TaskAttachments)
                .HasForeignKey(d => d.TasksId)
                .HasConstraintName("task_attachments_ibfk_1");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("users");

            entity.HasIndex(e => e.RoleId, "role_id");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("last_name");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.RoleId)
                .HasColumnType("int(11)")
                .HasColumnName("role_id");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("users_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
