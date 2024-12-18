﻿using api.Entities;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<ProductType> ProductType { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<SubCategory> SubCategory { get; set; }
        public DbSet<TaxCategory> Tax_Category { get; set; }
        public DbSet<InventoryMaster> InventoryMaster { get; set; }
        public DbSet<CustomerMaster> CustomerMaster { get; set; }
        public DbSet<PowerDetails> CustomerPower { get; set; }
        public DbSet<PowerDetailsList> CustomerPowerList { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
