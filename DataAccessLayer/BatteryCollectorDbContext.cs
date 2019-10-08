using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using DataTypeObject;
using System.Reflection;

namespace DataAccessLayer
{
    public class BatteryCollectorDbContext : DbContext
    {

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Discard>()
            .Property(sample => sample.Date)
            .HasColumnType("datetime");

            modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
                    .IsUnique();

            modelBuilder.Entity<User>()
            .Property(u => u.Name)
                    .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.Password)
                          .IsRequired();

            //modelBuilder.Entity<Discard>()
            //.HasOne<Material>(s => s.Material)
            //.WithOne(ad => ad.Discard)
            //.HasForeignKey<Discard>(ad => ad.MaterialId);


            //modelBuilder.Entity<Discard>()
            //.HasOne<Place>(s => s.Place)
            //.WithOne(ad => ad.Discard)
            //.HasForeignKey<Discard>(ad => ad.PlaceId);

            //modelBuilder.Entity<Discard>()
            //.HasOne<User>(s => s.User)
            //.WithOne(ad => ad.Discard)
            //.HasForeignKey<Discard>(ad => ad.UserId);

            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

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
        public DbSet<AskAndAnswers> AskAndAnswers { get; set; }
    }
}