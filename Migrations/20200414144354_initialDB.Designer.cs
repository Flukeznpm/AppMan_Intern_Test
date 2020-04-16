﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TodoApi.Models;

namespace TodoApi.Migrations
{
    [DbContext(typeof(TodoContext))]
    [Migration("20200414144354_initialDB")]
    partial class initialDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("TodoApi.Models.Student", b =>
                {
                    b.Property<long>("std_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("std_fname")
                        .HasColumnType("text");

                    b.Property<string>("std_lname")
                        .HasColumnType("text");

                    b.HasKey("std_Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("TodoApi.Models.StudentinUniversity", b =>
                {
                    b.Property<int>("std_id")
                        .HasColumnType("integer");

                    b.Property<int>("uni_id")
                        .HasColumnType("integer");

                    b.Property<long?>("Studentstd_Id")
                        .HasColumnType("bigint");

                    b.Property<long?>("Universityuni_Id")
                        .HasColumnType("bigint");

                    b.HasKey("std_id", "uni_id");

                    b.HasIndex("Studentstd_Id");

                    b.HasIndex("Universityuni_Id");

                    b.ToTable("StudentinUniversities");
                });

            modelBuilder.Entity("TodoApi.Models.University", b =>
                {
                    b.Property<long>("uni_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("uni_name")
                        .HasColumnType("text");

                    b.HasKey("uni_Id");

                    b.ToTable("Universitys");
                });

            modelBuilder.Entity("TodoApi.Models.StudentinUniversity", b =>
                {
                    b.HasOne("TodoApi.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("Studentstd_Id");

                    b.HasOne("TodoApi.Models.University", "University")
                        .WithMany()
                        .HasForeignKey("Universityuni_Id");
                });
#pragma warning restore 612, 618
        }
    }
}