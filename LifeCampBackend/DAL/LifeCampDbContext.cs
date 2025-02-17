using LifeCamp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace LifeCamp.DAL
{
    public class LifeCampDbContext : DbContext
    {
        public LifeCampDbContext(DbContextOptions<LifeCampDbContext> options)
          : base(options)
        {
        }
        public DbSet<CampDetail> CampDetails { get; set; }
        public DbSet<UserLogin> UserLogins { get; set; }
        public DbSet<AdminLogin> AdminLogins { get; set; }
        public DbSet<UserDetail> UserDetails { get; set; }

    }
}
