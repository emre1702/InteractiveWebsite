using InteractiveWebsite.Common.Enums;
using Microsoft.AspNetCore.Mvc;
using System;

namespace InteractiveWebsite.Filters.LevelRequirement
{
    public class LevelRequirementAttribute : TypeFilterAttribute
    {
        public NavigationItem Navigation { get; }
        public string ClaimId { get; }
        public string Info { get; }

        public LevelRequirementAttribute(string claimId, NavigationItem navigation, string info) : base(typeof(LevelRequirementFilter))
        {
            Order = int.MinValue;
            Navigation = navigation;
            ClaimId = claimId;
            Info = info;
            Arguments = new object[] { navigation, claimId, info };
        }

        public LevelRequirementAttribute(NavigationItem navigation, string info) : this(Enum.GetName(navigation)!, navigation, info) { }
    }
}
