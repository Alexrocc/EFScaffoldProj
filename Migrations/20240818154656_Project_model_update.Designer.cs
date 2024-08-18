﻿// <auto-generated />
using System;
using EFScaffoldProj.Core.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EFScaffoldProj.Migrations
{
    [DbContext(typeof(PmsapiContext))]
    [Migration("20240818154656_Project_model_update")]
    partial class Project_model_update
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("latin1_swedish_ci")
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.HasCharSet(modelBuilder, "latin1");
            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("EFScaffoldProj.Core.Models.Priority", b =>
                {
                    b.Property<int>("PriorityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("PriorityId"));

                    b.Property<string>("PriorityDef")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.HasKey("PriorityId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "PriorityId" }, "priority_id");

                    b.ToTable("priorities", (string)null);
                });

            modelBuilder.Entity("EFScaffoldProj.Core.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("description");

                    b.Property<DateOnly?>("EndDate")
                        .IsRequired()
                        .HasColumnType("date")
                        .HasColumnName("end_date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("name");

                    b.Property<int>("PriorityId")
                        .HasColumnType("int(11)")
                        .HasColumnName("priority_id");

                    b.Property<int>("ProjectCategoriesId")
                        .HasColumnType("int(11)")
                        .HasColumnName("project_categories_id");

                    b.Property<DateOnly?>("StartDate")
                        .IsRequired()
                        .HasColumnType("date")
                        .HasColumnName("start_date");

                    b.Property<int>("StatusId")
                        .HasColumnType("int(11)")
                        .HasColumnName("status_id");

                    b.Property<int>("UsersManagerId")
                        .HasColumnType("int(11)")
                        .HasColumnName("users_manager_id");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex(new[] { "PriorityId" }, "priority_id")
                        .HasDatabaseName("priority_id1");

                    b.HasIndex(new[] { "ProjectCategoriesId" }, "project_categories_id");

                    b.HasIndex(new[] { "StatusId" }, "status_id");

                    b.HasIndex(new[] { "UsersManagerId" }, "users_manager_id");

                    b.ToTable("projects", (string)null);
                });

            modelBuilder.Entity("EFScaffoldProj.Core.Models.ProjectCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("project_categories", (string)null);
                });

            modelBuilder.Entity("EFScaffoldProj.Core.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("roles", (string)null);
                });

            modelBuilder.Entity("EFScaffoldProj.Core.Models.Status", b =>
                {
                    b.Property<int>("StatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("StatusId"));

                    b.Property<string>("StatusName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.HasKey("StatusId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "StatusId" }, "status_id")
                        .HasDatabaseName("status_id1");

                    b.ToTable("statuses", (string)null);
                });

            modelBuilder.Entity("EFScaffoldProj.Core.Models.Task", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("description");

                    b.Property<DateOnly?>("DueDate")
                        .HasColumnType("date")
                        .HasColumnName("due_date");

                    b.Property<int>("PriorityId")
                        .HasColumnType("int(11)")
                        .HasColumnName("priority_id");

                    b.Property<int?>("ProjectsId")
                        .HasColumnType("int(11)")
                        .HasColumnName("projects_id");

                    b.Property<int>("StatusId")
                        .HasColumnType("int(11)")
                        .HasColumnName("status_id");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("title");

                    b.Property<int?>("UsersId")
                        .HasColumnType("int(11)")
                        .HasColumnName("users_id");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "PriorityId" }, "priority_id")
                        .HasDatabaseName("priority_id2");

                    b.HasIndex(new[] { "ProjectsId" }, "projects_id");

                    b.HasIndex(new[] { "StatusId" }, "status_id")
                        .HasDatabaseName("status_id2");

                    b.HasIndex(new[] { "UsersId" }, "users_id");

                    b.ToTable("tasks", (string)null);
                });

            modelBuilder.Entity("EFScaffoldProj.Core.Models.TaskAttachment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<byte[]>("FileData")
                        .IsRequired()
                        .HasColumnType("blob")
                        .HasColumnName("file_data");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("file_name");

                    b.Property<int?>("TasksId")
                        .HasColumnType("int(11)")
                        .HasColumnName("tasks_id");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "TasksId" }, "tasks_id");

                    b.ToTable("task_attachments", (string)null);
                });

            modelBuilder.Entity("EFScaffoldProj.Core.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("last_name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("password");

                    b.Property<int>("RoleId")
                        .HasColumnType("int(11)")
                        .HasColumnName("role_id");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("username");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "RoleId" }, "role_id");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("EFScaffoldProj.Core.Models.Project", b =>
                {
                    b.HasOne("EFScaffoldProj.Core.Models.Priority", "Priority")
                        .WithMany("Projects")
                        .HasForeignKey("PriorityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFScaffoldProj.Core.Models.ProjectCategory", "ProjectCategories")
                        .WithMany("Projects")
                        .HasForeignKey("ProjectCategoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("projects_ibfk_1");

                    b.HasOne("EFScaffoldProj.Core.Models.Status", "Status")
                        .WithMany("Projects")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFScaffoldProj.Core.Models.User", "UsersManager")
                        .WithMany("Projects")
                        .HasForeignKey("UsersManagerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("projects_ibfk_2");

                    b.Navigation("Priority");

                    b.Navigation("ProjectCategories");

                    b.Navigation("Status");

                    b.Navigation("UsersManager");
                });

            modelBuilder.Entity("EFScaffoldProj.Core.Models.Task", b =>
                {
                    b.HasOne("EFScaffoldProj.Core.Models.Priority", "Priority")
                        .WithMany("Tasks")
                        .HasForeignKey("PriorityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFScaffoldProj.Core.Models.Project", "Projects")
                        .WithMany("Tasks")
                        .HasForeignKey("ProjectsId")
                        .HasConstraintName("tasks_ibfk_1");

                    b.HasOne("EFScaffoldProj.Core.Models.Status", "Status")
                        .WithMany("Tasks")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFScaffoldProj.Core.Models.User", "Users")
                        .WithMany("Tasks")
                        .HasForeignKey("UsersId")
                        .HasConstraintName("tasks_ibfk_2");

                    b.Navigation("Priority");

                    b.Navigation("Projects");

                    b.Navigation("Status");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("EFScaffoldProj.Core.Models.TaskAttachment", b =>
                {
                    b.HasOne("EFScaffoldProj.Core.Models.Task", "Tasks")
                        .WithMany("TaskAttachments")
                        .HasForeignKey("TasksId")
                        .HasConstraintName("task_attachments_ibfk_1");

                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("EFScaffoldProj.Core.Models.User", b =>
                {
                    b.HasOne("EFScaffoldProj.Core.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .IsRequired()
                        .HasConstraintName("users_ibfk_1");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("EFScaffoldProj.Core.Models.Priority", b =>
                {
                    b.Navigation("Projects");

                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("EFScaffoldProj.Core.Models.Project", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("EFScaffoldProj.Core.Models.ProjectCategory", b =>
                {
                    b.Navigation("Projects");
                });

            modelBuilder.Entity("EFScaffoldProj.Core.Models.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("EFScaffoldProj.Core.Models.Status", b =>
                {
                    b.Navigation("Projects");

                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("EFScaffoldProj.Core.Models.Task", b =>
                {
                    b.Navigation("TaskAttachments");
                });

            modelBuilder.Entity("EFScaffoldProj.Core.Models.User", b =>
                {
                    b.Navigation("Projects");

                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}
