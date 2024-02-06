﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudentApplication1.Data;

#nullable disable

namespace StudentApplication1.Migrations
{
    [DbContext(typeof(StudentDbContext))]
    [Migration("20240205113052_Initial-migration")]
    partial class Initialmigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("StudentApplication.Models.Mark", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Mark1")
                        .HasColumnType("int");

                    b.Property<int>("Mark2")
                        .HasColumnType("int");

                    b.Property<int>("Mark3")
                        .HasColumnType("int");

                    b.Property<int>("Mark4")
                        .HasColumnType("int");

                    b.Property<int>("Mark5")
                        .HasColumnType("int");

                    b.Property<int>("Mark6")
                        .HasColumnType("int");

                    b.Property<Guid>("studentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("studentId");

                    b.ToTable("Mark");
                });

            modelBuilder.Entity("StudentApplication.Models.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Class")
                        .HasColumnType("int");

                    b.Property<string>("Division")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ParentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("StudentApplication.Models.Mark", b =>
                {
                    b.HasOne("StudentApplication.Models.Student", "student")
                        .WithMany()
                        .HasForeignKey("studentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("student");
                });
#pragma warning restore 612, 618
        }
    }
}
