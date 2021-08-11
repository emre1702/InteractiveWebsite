using InteractiveWebsite.Common.Models.Settings;
using System.Collections.Generic;

namespace InteractiveWebsite.Common.Interfaces.Settings
{
    public interface IPossibleClaimsSettingsStorage
    {
        void InitialLoad();
        IReadOnlyList<ClaimsSettingsWithoutValues> ClaimsSettingsWithoutValues { get; }
    }
}