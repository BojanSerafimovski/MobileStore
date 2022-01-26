using Microsoft.EntityFrameworkCore;
using MobileStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileStore.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Mobile>()
            //    .HasOne(p => p.Manufacturer)
            //    .WithMany(b => b.Mobiles)
            //    .HasForeignKey("ManufacturerId")
            //    .IsRequired()
            //    .OnDelete(DeleteBehavior.Cascade);
        }

        public DbSet<Mobile> Mobiles { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<MobileDescription> MobileDescriptions { get; set; }
    }
}
