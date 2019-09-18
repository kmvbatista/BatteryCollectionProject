using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using DataTypeObject;

namespace DataAccessLayer
{
    public class BatteryCollectorDbContext : DbContext
    {   
        public BatteryCollectorDbContext(DbContextOptions<BatteryCollectorDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Discard> Discards { get; set; }
        public DbSet<UserPoints> UserPoints { get; set; }
        public DbSet<Place> Places { get; set; }

    }
}