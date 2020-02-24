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

        protected override void OnConfiguring(DbContextOptionsBuilder builder) {
            if (!builder.IsConfigured) {
                builder.UseLazyLoadingProxies();
                var connStr = @"server=localhost\sqlexpress; database = CustEfDb; trusted_connection = true;";
                builder.UseSqlServer(connStr);
            }

        }
    }
}
