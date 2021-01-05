using Microsoft.EntityFrameworkCore;
using RSNetwApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RSNetwApp.Repositories.Contexts
{
    public class RSNetwDbContext : DbContext
    {
        public RSNetwDbContext(DbContextOptions<RSNetwDbContext> options)
          : base(options)
        {
        }

        public DbSet<CredentialsEntity> CredentialsEntities { get; set; }
        public DbSet<UserProfileEntity> UserProfileEntities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CredentialsEntity>().HasIndex(e => e.Username).IsUnique();
        }
    }
}
