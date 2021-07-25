using InteractiveWebsite.Common.Classes.Information;
using InteractiveWebsite.Common.Interfaces.Information;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace InteractiveWebsite.Core.Controllers
{
    public class NewsController : CustomControllerBase
    {
        private readonly INewsService _newsService;

        public NewsController(INewsService newsService) => _newsService = newsService;

        [HttpGet]
        public Task<IEnumerable<WebNews>> LoadNews([FromQuery] int loadedLastNewsId = 0)
            => _newsService.Load(loadedLastNewsId);

        [HttpPost]
        public async Task<IActionResult> CreateNews([FromBody] CreateNewsData createNewsData)
        {
            await _newsService.Add(createNewsData.Content, User.FindFirstValue(ClaimTypes.NameIdentifier));
            return Ok();
        }
    }
}
