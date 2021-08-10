using InteractiveWebsite.Common.Enums;
using Microsoft.AspNetCore.Mvc;
using System;

namespace InteractiveWebsite.Core.Filters.LevelRequirement
{
    public class LevelRequirementAttribute : TypeFilterAttribute
    {
        public LevelRequirementAttribute(string claimId, string info) : base(typeof(LevelRequirementFilter))
        {
            Order = int.MinValue;
            Arguments = new object[] { claimId, info };
        }

        public LevelRequirementAttribute(NavigationItem navigation, string info) : this(Enum.GetName(navigation)!, info) { }
    }
}
