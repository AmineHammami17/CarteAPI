using CarteAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace CarteAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Ligne> Lignes { get; set; }
        public DbSet<Equipe> Equipes { get; set; }

        public DbSet<ReferenceFile> ReferenceFiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");

            // Additional configuration can go here
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies(false);
                optionsBuilder.UseSqlServer("Data Source=Amine\\SQLEXPRESS;Database=CarteDB;Trusted_Connection=true;TrustServerCertificate=true");
            }
        }
    }
}
