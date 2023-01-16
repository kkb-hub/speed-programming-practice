using Entityclass;
using FSESpeedProgrammingLib;
using Microsoft.EntityFrameworkCore;
using Razor.Models;


namespace Razor.Controllers
{

    public class PCWBSwithBaseController : ApiBaseController<PCWBSDbContext, Tb1>
    {
        public PCWBSwithBaseController(PCWBSDbContext context) : base(context)
        {
        }
        public DbSet<Tb1> Tb1 { get; set; }
        public DbSet<Tb1> Tb2 { get; set; }
    }

    public class EntityBwithBaseController : ApiBaseController<PCWBSDbContext, Tb2>
    {
        public EntityBwithBaseController(PCWBSDbContext context) : base(context)
        {
        }
        public DbSet<Tb2> Tb2 { get; set; }
    }
}