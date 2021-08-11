using InteractiveWebsite.Common.Enums;

namespace InteractiveWebsite.Common.WebModels.Settings
{
    public record ClaimsSettingsWebConfiguration(string ClaimId, NavigationItem Navigation, string? Info, int MinLevel = int.MaxValue);
}
