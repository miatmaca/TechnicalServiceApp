using Core.Entities.Entity;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class TServiceContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-97A2EM3\SQLEXPRESS;Database=TechnicalServiceAppDb;Trusted_Connection=true");

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<FaultInfo> FaultInfos { get; set; }
        public DbSet<MadeProces> MadeProcess { get; set; }
        public DbSet<MaterialUsed> MaterialUseds { get; set; }
        public DbSet<ProcessControl> ProcessControls { get; set; }
        public DbSet<ProductInfo> ProductInfos { get; set; }
        public DbSet<StateControl> StateControls { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
          .HasKey(p => p.CustomerId);

            modelBuilder.Entity<User>()
        .HasKey(p => p.Id);

            modelBuilder.Entity<FaultInfo>()
         .HasKey(p => p.ProductId);

            modelBuilder.Entity<MadeProces>()
        .HasKey(p => p.ProductId);

            modelBuilder.Entity<MaterialUsed>()
        .HasKey(p => p.ProductId);

            modelBuilder.Entity<ProcessControl>()
        .HasKey(p => p.ProcessId);

            modelBuilder.Entity<ProductInfo>()
        .HasKey(p => p.ProductId);

            modelBuilder.Entity<StateControl>()
        .HasKey(p => p.StateId);

        }

    }

   
}
