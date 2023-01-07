using Microsoft.EntityFrameworkCore;
using PCWBSClass;
//using ConsoleApp;


namespace Razor.Models
{
    public class PCWBSDbContext : DbContext
    {
        public PCWBSDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<PCWBS> PCWBS { get; set; }
        //public DbSet<TestCodeClass> TestCode { get; set; }

    }
}
