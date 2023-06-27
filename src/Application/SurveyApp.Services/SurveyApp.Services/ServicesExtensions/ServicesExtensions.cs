using System.Security.Claims;

namespace SurveyApp.Services.ServicesExtensions;

public static class ServicesExtensions
{
    public static string GetClaim(this List<Claim> claims, string name)
    {
        var claim = claims.FirstOrDefault(x => x.Type == name)?.Value;
        return claim ?? string.Empty;
    }
}