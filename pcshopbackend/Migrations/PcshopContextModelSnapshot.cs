﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using pcshopbackend.Data;

#nullable disable

namespace pcshopbackend.Migrations
{
    [DbContext(typeof(PcshopContext))]
    partial class PcshopContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("pcshopbackend.Models.Part", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PartCategoryID")
                        .HasColumnType("int");

                    b.Property<int?>("PrebuildID")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("PartCategoryID");

                    b.HasIndex("PrebuildID");

                    b.ToTable("Parts");
                });

            modelBuilder.Entity("pcshopbackend.Models.PartCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PartCategories");
                });

            modelBuilder.Entity("pcshopbackend.Models.Prebuild", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Prebuilds");
                });

            modelBuilder.Entity("pcshopbackend.Models.Part", b =>
                {
                    b.HasOne("pcshopbackend.Models.PartCategory", "PartCategory")
                        .WithMany("Parts")
                        .HasForeignKey("PartCategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("pcshopbackend.Models.Prebuild", "Prebuild")
                        .WithMany("parts")
                        .HasForeignKey("PrebuildID");

                    b.Navigation("PartCategory");

                    b.Navigation("Prebuild");
                });

            modelBuilder.Entity("pcshopbackend.Models.PartCategory", b =>
                {
                    b.Navigation("Parts");
                });

            modelBuilder.Entity("pcshopbackend.Models.Prebuild", b =>
                {
                    b.Navigation("parts");
                });
#pragma warning restore 612, 618
        }
    }
}
