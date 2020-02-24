using System;
using CapCSharpEFLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace CapCSharpEFLibrary
{
    public class AppDbContext : DbContext {
        public AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){ }

        public virtual DbSet<Customer> Customers { get; set; }// use plurals of class name, this has to be somewhere inside class this is the first of the lists of tables we can access

        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<Product> Products { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder builder) {
            if (!builder.IsConfigured) {
                builder.UseLazyLoadingProxies();
                var connStr = @"server=localhost\sqlexpress; database = CustEfDb; trusted_connection = true;";
                builder.UseSqlServer(connStr);
            }
        }

        // required in capstone to make columns unique  this is called Fluent API
        protected override void OnModelCreating(ModelBuilder model) {
            model.Entity<Product>(e => {
                e.HasKey(x => x.Id);
                e.Property(x => x.Code).HasMaxLength(10).IsRequired();
                e.Property(x => x.Name).HasMaxLength(30).IsRequired();
                e.Property(x => x.Price);
                e.HasIndex(x => x.Code).IsUnique();
            });
        }
    }
}
