using System.Security.Claims;

namespace TaskBoardApp.Extensions
{
    public static class ClaimsPrincipalExtention
    {

        public static string GetId(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
