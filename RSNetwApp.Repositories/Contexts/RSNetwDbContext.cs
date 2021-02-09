using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RSNetwApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RSNetwApp.Repositories.Contexts
{
    public class RSNetwDbContext : IdentityDbContext<UserProfileEntity>
    {
        public RSNetwDbContext(DbContextOptions<RSNetwDbContext> options)
          : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<UserProfileEntity> UserProfileEntities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserProfileEntity>().HasIndex(e => e.UserName).IsUnique();
        }
    }
}
