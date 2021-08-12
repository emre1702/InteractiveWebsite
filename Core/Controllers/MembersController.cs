using InteractiveWebsite.Common.Interfaces.Members;
using InteractiveWebsite.Common.WebModels.Members;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace InteractiveWebsite.Core.Controllers
{
    public class MembersController : CustomControllerBase
    {
        private readonly IMembersDataService _membersDataService;

        public MembersController(IMembersDataService membersDataService)
            => _membersDataService = membersDataService;

        [HttpGet]
        public IAsyncEnumerable<MemberData> GetMemberDatas(string sort, bool? asc, int page)
            => _membersDataService.GetMemberDatas(sort, asc, page);
    }
}
