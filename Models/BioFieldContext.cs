using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;

namespace BioField.Models
{
    public class BioFieldContext : IdentityDbContext<IdentityUser>
    {
        public virtual DbSet<Journals> Journals { get; set; }
        public DbSet<Entries> Entries { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public BioFieldContext(DbContextOptions options) : base(options) { }
    }
}