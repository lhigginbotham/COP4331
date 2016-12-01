using CascadeFinance.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CascadeFinance.Data
{
    public class HandleReadDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Widgets> Widgets { get; set; }
        public DbSet<Expenses> Expenses { get; set; }

        public HandleReadDbContext(DbContextOptions<HandleReadDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
