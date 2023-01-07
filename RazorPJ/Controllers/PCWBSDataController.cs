using PCWBSClass;
using FSESpeedProgrammingLib;
using Razor.Models;


namespace Razor.Controllers
{

    public class PCWBSwithBaseController : ApiBaseController<PCWBSDbContext, PCWBS>
    {
        public PCWBSwithBaseController(PCWBSDbContext context) : base(context)
        {
        }
    }
}