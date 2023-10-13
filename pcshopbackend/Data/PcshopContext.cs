using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using pcshopbackend.Models;

namespace pcshopbackend.Data;

public partial class PcshopContext : DbContext
{

    public DbSet<Part> Parts { get; set; }

    public DbSet<PartCategory> PartCategories { get; set; }

    public DbSet<Prebuild> Prebuilds { get; set; }

   


    public PcshopContext()
    {}

    public PcshopContext(DbContextOptions<PcshopContext> options)
        : base(options)
    {}
    

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=pcshop;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {


        modelBuilder.Entity<PartCategory>()
      .HasMany(e => e.Parts)
      .WithOne(e => e.PartCategory)
      .HasForeignKey(e => e.PartCategoryID)
      .IsRequired();

        modelBuilder.Entity<Prebuild>()
      .HasMany(e => e.parts)
      .WithOne(e => e.Prebuild)
      .HasForeignKey(e => e.PrebuildID)
      .IsRequired(false);
    }


    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
