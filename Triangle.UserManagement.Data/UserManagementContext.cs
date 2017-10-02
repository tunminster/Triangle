using Microsoft.EntityFrameworkCore;
using System;

namespace Triangle.UserManagement.Data
{
    public class UserManagementContext : DbContext
    {
        public UserManagementContext(DbContextOptions<UserManagementContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Course>().ToTable("Course");
        }
    }
}
