using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TWHelp.Models;

namespace TWHelp.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<long>, long>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Topic> Topics{ get; set; }
        public DbSet<Comment> Comments { get; set; }

        public DbSet<Question> Questions{ get; set; }

        public DbSet<Test> Tests{ get; set; }

        public DbSet<Answer> Answers{ get; set; }
    }
}
