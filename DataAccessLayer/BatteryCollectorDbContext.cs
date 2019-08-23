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
    }
}