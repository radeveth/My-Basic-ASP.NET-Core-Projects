namespace CarRentingSystem.Infrastructure
{
    using CarRentingSystem.Data;
    using System.Security.Claims;
    
    public static class ClaimsPrincipalExtensions
    {
        public static string GetId
            (ClaimsPrincipal user)
        {
            return user.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
    }
}
