using InteractiveWebsite.Common.Enums;
using InteractiveWebsite.Common.Interfaces.Settings;
using InteractiveWebsite.Common.Models.Settings;
using InteractiveWebsite.Database;
using InteractiveWebsite.Filters.LevelRequirement;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace InteractiveWebsite.Services.Settings
{
    public class PossibleClaimsSettingsStorage : IPossibleClaimsSettingsStorage
    {
        public IReadOnlyList<ClaimsSettingsWithoutValues> ClaimsSettingsWithoutValues => _claimsSettingsWithoutValues;

        private readonly List<ClaimsSettingsWithoutValues> _claimsSettingsWithoutValues = new();

        public void InitialLoad()
        {
            var coreAssembly = Assembly.GetCallingAssembly();
            LoadNavigations();
            LoadLevelRequirementAttributes(coreAssembly);
        }

        private void LoadNavigations()
        {
            var navigations = Enum.GetValues<NavigationItem>();
            var settings = navigations.Select(n => new ClaimsSettingsWithoutValues(Enum.GetName(n)!, n, $"Navigation: {Enum.GetName(n)}"));
            _claimsSettingsWithoutValues.AddRange(settings);
        }

        private void LoadLevelRequirementAttributes(Assembly searchInAssembly)
        {
            // Only applied for this project because controllers are only here
            var classes = searchInAssembly.DefinedTypes;
            var allMethods = classes.SelectMany(c => c.DeclaredMethods);
            var levelRequirementAttributes = allMethods.Select(m => m.GetCustomAttribute<LevelRequirementAttribute>(false)).Where(m => m is not null);
            var settings = levelRequirementAttributes.Select(a => new ClaimsSettingsWithoutValues(a!.ClaimId, a.Navigation, a.Info));
            _claimsSettingsWithoutValues.AddRange(settings);
        }
    }
}
