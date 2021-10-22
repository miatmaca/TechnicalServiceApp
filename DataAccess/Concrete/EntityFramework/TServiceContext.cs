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
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-97A2EM3\SQLEXPRESS;Database=TechnicalServiceDb;Trusted_Connection=true");

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<User> Users { get; set; }       
        public DbSet<MadeProces> MadeProcess { get; set; }            
        public DbSet<FaultState> FaultStates { get; set; }
        public DbSet<ProductInfo> ProductInfos { get; set; }
        public DbSet<StateControl> StateControls { get; set; }
        public DbSet<ProcesState> ProcesStates { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set;}
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Oem> Oems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet <EndData> EndDatas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {           
            modelBuilder.Entity<Customer>()
        .HasKey(p => p.Id);
            modelBuilder.Entity<User>()
       .HasKey(p => p.Id);
            modelBuilder.Entity<MadeProces>()
       .HasKey(p => p.Id);
            modelBuilder.Entity<FaultState>()
       .HasKey(p => p.Id);
            modelBuilder.Entity<FaultState>()
       .HasKey(p => p.Id);
            modelBuilder.Entity<ProductInfo>()
       .HasKey(p => p.ProductId);
            modelBuilder.Entity<StateControl>()
       .HasKey(p => p.Id);
            modelBuilder.Entity<OperationClaim>()
       .HasKey(p => p.Id);
            modelBuilder.Entity<UserOperationClaim>()
       .HasKey(p => p.Id);
            modelBuilder.Entity<Brand>()
       .HasKey(p => p.Id);
            modelBuilder.Entity<Oem>()
       .HasKey(p => p.Id);
            modelBuilder.Entity<Category>()
       .HasKey(p => p.Id);
            modelBuilder.Entity<EndData>()
     .HasKey(p => p.Id);






        }

    }

   
}
