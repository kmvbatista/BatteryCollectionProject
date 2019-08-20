using Microsoft.EntityFrameworkCore;
using System;
using DataTypeObject;

namespace DataAccessLayer
{
    public class MaterialDbContext : DbContext
    {
        public MaterialDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {

        }
        public DbSet<Material> Materials { get; set; }
    }
}
