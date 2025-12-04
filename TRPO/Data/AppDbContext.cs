using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRPO.Classes;

namespace TRPO.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Users;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
            new Role { Id = 1, Title = "Пользователь" },
            new Role { Id = 2, Title = "Менеджер" },
            new Role { Id = 3, Title = "Администратор" }
            );

            modelBuilder.Entity<User>().HasData(
            new User {ID=1, Login = "asd", Name = "Adolf", Email = "romand@gmail.com", Password = "qwerty1_W", CreatedAt = DateTime.Today, RoleId = 1 }
            );

            modelBuilder.Entity<User>()
            .HasOne(s => s.Profile)
            .WithOne(ps => ps.User)
            .HasForeignKey<UserProfile>(ps => ps.UserId);


            modelBuilder.Entity<Role>()
            .HasMany(g => g.Users)
            .WithOne(s => s.Role)
            .HasForeignKey(s => s.RoleId);
        }
    }
}
