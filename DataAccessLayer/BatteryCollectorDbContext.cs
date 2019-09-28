using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using DataTypeObject;

namespace DataAccessLayer
{
public class BatteryCollectorDbContext : DbContext
{   
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    modelBuilder.Entity<Discard>()
                .Property(sample => sample.Date)
                .HasColumnType("date");


    base.OnModelCreating(modelBuilder);
    }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=turnitgreenerdb.cgzah6z6klsd.us-east-2.rds.amazonaws.com; Initial Catalog=turnitgreener;User ID=kmvbatista;Password=Ke159951h;Connect Timeout=360;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

            public BatteryCollectorDbContext(DbContextOptions<BatteryCollectorDbContext> options) : base(options)
            {

            }

            public DbSet<User> Users { get; set; }
            public DbSet<Material> Materials { get; set; }
            public DbSet<Discard> Discards { get; set; }
            public DbSet<Place> Place { get; set; }

        }
}