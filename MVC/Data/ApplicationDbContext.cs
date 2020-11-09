using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVC.Models;

namespace MVC.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Groups> Groups { get; set; }
        public DbSet<GroupRoles> GroupRoles { get; set; }
        public DbSet<RoleGroupUsers> RoleGroupUsers { get; set; }
    }
}
