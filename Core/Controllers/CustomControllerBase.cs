using Microsoft.AspNetCore.Mvc;

namespace InteractiveWebsite.Core.Controllers
{
    [Route("{language}/api/[controller]")]
    public class CustomControllerBase : ControllerBase
    {
    }
}
