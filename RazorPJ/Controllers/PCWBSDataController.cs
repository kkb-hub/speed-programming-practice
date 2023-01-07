using Entityclass;
using FSESpeedProgrammingLib;
using Microsoft.EntityFrameworkCore;
using Razor.Models;


namespace Razor.Controllers
{

    public class PCWBSwithBaseController : ApiBaseController<PCWBSDbContext, EntytyA>
    {
        public PCWBSwithBaseController(PCWBSDbContext context) : base(context)
        {
        }
        public DbSet<EntytyA> EntityA { get; set; }
        public DbSet<EntytyA> EntityB { get; set; }
    }

    public class EntityBwithBaseController : ApiBaseController<PCWBSDbContext, EntityB>
    {
        public EntityBwithBaseController(PCWBSDbContext context) : base(context)
        {
        }
        public DbSet<EntytyA> EntityB { get; set; }
    }
}