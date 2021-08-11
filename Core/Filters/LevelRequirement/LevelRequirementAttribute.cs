using InteractiveWebsite.Common.Enums;
using Microsoft.AspNetCore.Mvc;
using System;

namespace InteractiveWebsite.Core.Filters.LevelRequirement
{
    public class LevelRequirementAttribute : TypeFilterAttribute
    {
        public LevelRequirementAttribute(NavigationItem navigation, string claimId, string info) : base(typeof(LevelRequirementFilter))
        {
            Order = int.MinValue;
            Arguments = new object[] { navigation, claimId, info };
        }

        public LevelRequirementAttribute(NavigationItem navigation, string info) : this(navigation, Enum.GetName(navigation)!, info) { }
    }
}
