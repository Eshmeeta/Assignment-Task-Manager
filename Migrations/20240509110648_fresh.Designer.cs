﻿// <auto-generated />
using Assignment_Eshmeeta.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Assignment_Eshmeeta.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240509110648_fresh")]
    partial class fresh
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Assignment_Eshmeeta.Model.Tasks", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tasks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Collect the PRD from the client",
                            Status = "Completed",
                            Title = "Requirements Gathering"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Discuss the requirements with the team",
                            Status = "Completed",
                            Title = "Requirements Analysis"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Provide a suitable timeline to the client",
                            Status = "Completed",
                            Title = "Provide Timeline"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Develop the product",
                            Status = "In-Progress",
                            Title = "Development"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Test the product",
                            Status = "Incomplete",
                            Title = "Testing"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
