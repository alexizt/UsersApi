using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace WebApplicationEntityFramework.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Map table names
            modelBuilder.Entity<User>().ToTable("Users", "test");

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdValue);
                entity.HasIndex(e => e.Uuid).IsUnique();
                entity.Property(e => e.BirthDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
            });


            base.OnModelCreating(modelBuilder);
        }
    }
}
