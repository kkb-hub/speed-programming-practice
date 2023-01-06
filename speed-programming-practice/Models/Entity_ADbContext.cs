using Microsoft.EntityFrameworkCore;
using Entity_AClass;
//using ConsoleApp;


namespace speed_programming_practice.Models
{
    public class Entity_ADbContext : DbContext
    {
        public Entity_ADbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Entity_A> Entity_A { get; set; }
        //public DbSet<TestCodeClass> TestCode { get; set; }

    }
}
