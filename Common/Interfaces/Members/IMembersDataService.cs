using InteractiveWebsite.Common.WebModels.Members;
using System.Collections.Generic;

namespace InteractiveWebsite.Common.Interfaces.Members
{
    public interface IMembersDataService
    {
        IAsyncEnumerable<MemberData> GetMemberDatas(string sort, bool? asc, int page);
    }
}