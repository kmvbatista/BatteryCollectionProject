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
                .HasColumnType("datetime2");


    base.OnModelCreating(modelBuilder);
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