using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DL
{
    public class RRDBContext : DbContext
    {
        public RRDBContext() : base() { }
        public RRDBContext(DbContextOptions options) : base(options) { }

        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Review> Reviews { get; set; }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Restaurant>()
            .Property(restaurant => restaurant.Id)
            .ValueGeneratedOnAdd();
            modelBuilder.Entity<Review>()
            .Property(review => review.Id)
            .ValueGeneratedOnAdd();
        }*/
    }
}
