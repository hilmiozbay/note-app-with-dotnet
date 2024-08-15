using System;
using Microsoft.EntityFrameworkCore;
using Proje5.Models;

namespace Proje5.Utility
{
    public class UygulamaDbContext : DbContext
    {

        public UygulamaDbContext(DbContextOptions<UygulamaDbContext> options) : base(options) { }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<Notes> Notes{ get; set; }

        public DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>()
                .HasOne(u => u.Account)
                .WithOne(a => a.User)
                .HasForeignKey<Account>(a => a.UserId);

            modelBuilder.Entity<Account>()
                .HasMany(a => a.Notes)
                .WithOne(n => n.Account)
                .HasForeignKey(n => n.AccountId);


            base.OnModelCreating(modelBuilder);
        }


    }
}

