using GYMDatabaseProject.Models;
using GymProjectUI.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYMDatabaseProject.DataAccess
{
    public class DatabaseGYM : DbContext
    {
        public DbSet<Users> Users { get; set; }

        public DbSet<Admins> Admins { get; set; }

        public DbSet<Plans> Plans { get; set; }

        public DbSet<Messages> AdminMessages { get; set; }

        public DbSet<UsersCalendar> UserCalendar { get; set; }

        public DbSet<UserNotifications> UserNotifications { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=GYMDB;Trusted_Connection=True;MultipleActiveResultSets=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
