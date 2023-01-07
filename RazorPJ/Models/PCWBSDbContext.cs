using Microsoft.EntityFrameworkCore;
using Entityclass;


namespace Razor.Models
{
    public class PCWBSDbContext : DbContext
    {
        public PCWBSDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<EntytyA> Entity_A { get; set; }
        public DbSet<EntityB> Entity_B { get; set; }
    }
}
