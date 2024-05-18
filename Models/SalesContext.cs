using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace seperated_project.Models
{
    public class SalesContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Sale> Sales { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=assignment12EF;" +
                "Integrated Security=True;TrustServerCertificate=True");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .HasKey(c => c.ProductId);
            modelBuilder.Entity<Customer>()
                .HasKey(c => c.CustomerId);

            modelBuilder.Entity<Product>()
                .Property(x => x.Name)
                .HasColumnType("varchar(50)");
            modelBuilder.Entity<Customer>()
                .Property(x => x.CustomerName)
                .HasColumnType("varchar(100)");
            modelBuilder.Entity<Customer>()
                .Property(x => x.Email)
                .HasColumnType("varchar(80)");
            modelBuilder.Entity<Store>()
                .Property(x => x.Name)
                .HasColumnType("varchar(80)");

            modelBuilder.Entity<Product>()
                .Property(b => b.Name)
                .IsUnicode(true);
            modelBuilder.Entity<Customer>()
                .Property(b => b.CustomerName)
                .IsUnicode(true);
            modelBuilder.Entity<Customer>()
                .Property(b => b.Email)
                .IsUnicode(false);
            modelBuilder.Entity<Store>()
                .Property(b => b.Name)
                .IsUnicode(true);

            modelBuilder.Entity<Sale>()
                .Property(s => s.Date)
                .HasDefaultValueSql("GETDATE()");
        }
    }
}
