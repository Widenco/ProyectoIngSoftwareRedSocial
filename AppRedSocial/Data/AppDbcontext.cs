using System.Collections.Generic;
using System.Reflection.Emit;
using AppRedSocial.Models;
using Microsoft.EntityFrameworkCore;

namespace AppRedSocial.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "Admin" },
                new Role { Id = 2, Name = "Usuario" }
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}
