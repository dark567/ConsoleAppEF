﻿// <auto-generated />
using System;
using ConsoleAppEF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ConsoleAppEF.Migrations
{
    [DbContext(typeof(AppContext))]
    [Migration("20201220193448_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("ConsoleAppEF.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d96d0045-3177-4e96-a905-f61358f26cab"),
                            Age = 30,
                            Email = "Mubeen@gmail.com",
                            Name = "Mubeen",
                            Password = "123123"
                        },
                        new
                        {
                            Id = new Guid("b62b95f0-07cb-441f-8902-4e86065d7cdb"),
                            Age = 15,
                            Email = "Tahir@gmail.com",
                            Name = "Tahir",
                            Password = "321321"
                        },
                        new
                        {
                            Id = new Guid("7aa9b9fa-2ab4-4cd2-a23b-4db16092e41a"),
                            Age = 25,
                            Email = "Cheema@gmail.com",
                            Name = "Cheema",
                            Password = "123321"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}