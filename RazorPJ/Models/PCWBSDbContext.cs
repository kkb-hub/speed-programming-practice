using Microsoft.EntityFrameworkCore;
using Entityclass;


namespace Razor.Models
{
    public class PCWBSDbContext : DbContext
    {
        public PCWBSDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Tb1> Tb1 { get; set; }
        public DbSet<Tb2> Tb2 { get; set; }
    }
}
