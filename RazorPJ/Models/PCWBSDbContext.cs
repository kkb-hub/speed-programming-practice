using Microsoft.EntityFrameworkCore;
using EntityAclass;


namespace Razor.Models
{
    public class PCWBSDbContext : DbContext
    {
        public PCWBSDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<EntytyA> Entity_A { get; set; }
    }
}
