using EntityAclass;
using FSESpeedProgrammingLib;
using Razor.Models;


namespace Razor.Controllers
{

    public class PCWBSwithBaseController : ApiBaseController<PCWBSDbContext, EntytyA>
    {
        public PCWBSwithBaseController(PCWBSDbContext context) : base(context)
        {
        }
    }
}