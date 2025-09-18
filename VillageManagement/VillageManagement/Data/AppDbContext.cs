using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using VillageManagement.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace VillageManagement.Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<BirthRecord> BirthRecords { get; set; }
        public DbSet<DeathRecord> DeathRecords { get; set; }
        public DbSet<MarriageRecord> MarriageRecords { get; set; }

    }
}
