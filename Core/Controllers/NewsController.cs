using InteractiveWebsite.Common.Enums;
using InteractiveWebsite.Common.Interfaces.Information;
using InteractiveWebsite.Common.WebModels.Information;
using InteractiveWebsite.Filters.LevelRequirement;
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

        [LevelRequirement("LoadNews", NavigationItem.News, "Load news")]
        [HttpGet]
        public Task<IEnumerable<WebNews>> LoadNews([FromQuery] int loadedLastNewsId = 0)
            => _newsService.Load(loadedLastNewsId);

        [LevelRequirement("CreateNews", NavigationItem.News, "Create news")]
        [HttpPost]
        public async Task<IActionResult> CreateNews([FromBody] CreateNewsData createNewsData)
        {
            await _newsService.Add(createNewsData.Content, User.FindFirstValue(ClaimTypes.NameIdentifier));
            return Ok();
        }
    }
}
