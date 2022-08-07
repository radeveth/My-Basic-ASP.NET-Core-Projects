namespace CarRentingSystem.Infrastructure
{
    using CarRentingSystem.Data;
    using System.Security.Claims;
    
    public static class ClaimsPrincipalExtensions
    {
        public static string GetId
            (ClaimsPrincipal user)
        {
            string id = user.FindFirst(ClaimTypes.NameIdentifier).Value;

            return id;
        }
    }
}
