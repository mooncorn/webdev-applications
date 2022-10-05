﻿using Microsoft.EntityFrameworkCore;
using StudentManagement.Models;

namespace StudentManagement.DataSource
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
    }
}
