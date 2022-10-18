﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using onlinepizzawebapplication.Data;

#nullable disable

namespace onlinepizzawebapplication.Migrations
{
    [DbContext(typeof(FullStackDbContext))]
    partial class FullStackDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("onlinepizzawebapplication.Models.Categories", b =>
                {
                    b.Property<Guid>("categoryid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("categoryname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("categoryid");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("onlinepizzawebapplication.Models.login", b =>
                {
                    b.Property<Guid>("loginid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("loginid");

                    b.ToTable("login");
                });

            modelBuilder.Entity("onlinepizzawebapplication.Models.Orders", b =>
                {
                    b.Property<Guid>("orderid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("orderid");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("onlinepizzawebapplication.Models.Pizza", b =>
                {
                    b.Property<Guid>("pizzaid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("price")
                        .HasColumnType("int");

                    b.HasKey("pizzaid");

                    b.ToTable("Pizzas");
                });

            modelBuilder.Entity("onlinepizzawebapplication.Models.Reviews", b =>
                {
                    b.Property<Guid>("reviewid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("pizzaname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("rating")
                        .HasColumnType("int");

                    b.HasKey("reviewid");

                    b.ToTable("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
