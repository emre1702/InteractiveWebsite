using InteractiveWebsite.Common;
using InteractiveWebsite.Common.Interfaces.Members;
using InteractiveWebsite.Common.WebModels.Members;
using InteractiveWebsite.Database;
using InteractiveWebsite.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InteractiveWebsite.Services.Members
{
    public class MembersDataService : IMembersDataService
    {
        private readonly AppDbContext _dbContext;

        public MembersDataService(AppDbContext dbContext)
            => _dbContext = dbContext;

        public async IAsyncEnumerable<MemberData> GetMemberDatas(string sort, bool? asc, int page)
        {
            var appUsers = await GetAppUsers(sort, asc, page);
            foreach (var appUser in appUsers)
            {
                var memberData = new MemberData(
                    appUser.NumberId,
                    $"{appUser.Name} {appUser.Surname}",
                    appUser.Sex,
                    appUser.Birthdate,
                    appUser.Created,
                    appUser.LastOnline,
                    appUser.Postcode,
                    appUser.IsAdmin,
                    appUser.Email
                );
                yield return memberData;
            }
        }

        private Task<List<AppUser>> GetAppUsers(string sort, bool? asc, int page)
        {
            var membersQuery = CreateQuery(sort, asc, page);
            return membersQuery.ToListAsync();
        }

        private IQueryable<AppUser> CreateQuery(string sort, bool? asc, int page)
        {
            var members = _dbContext.Users
               .Skip(page * Constants.MaxMembersPerPage)
               .Take(Constants.MaxMembersPerPage);
            if (sort is not { Length: > 0 })
                return members;

            if (asc == true)
                members = members.OrderBy(m => EF.Property<object>(m, sort));
            else
                members = members.OrderByDescending(m => EF.Property<object>(m, sort));
            return members;
        }
    }
}
