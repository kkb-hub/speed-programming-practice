using Entity_AClass;
using FSESpeedProgrammingLib;
using speed_programming_practice.Models;


namespace speed_programming_practice.Controllers
{

    public class Entity_AwithBaseController : ApiBaseController<Entity_ADbContext, Entity_A>
    {
        public Entity_AwithBaseController(Entity_ADbContext context) : base(context)
        {
        }
    }
}