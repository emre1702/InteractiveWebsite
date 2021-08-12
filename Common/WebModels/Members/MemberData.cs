using System;

namespace InteractiveWebsite.Common.WebModels.Members
{
    public record MemberData(int Id, string Name, string Sex, DateTime? BirthDate, DateTime Created, DateTime? LastOnline, int Postcode, bool IsAdmin, string Email);
}
