using InteractiveWebsite.Common.Interfaces.Pages;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace InteractiveWebsite.Core.Controllers
{
    public class PagesController : CustomControllerBase
    {
        private readonly INavigationService _navigationService;

        public PagesController(INavigationService navigationService)
            => _navigationService = navigationService;

        [HttpGet]
        public IAsyncEnumerable<string> GetNavigations()
            => _navigationService.GetNavigations(User);
    }
}
