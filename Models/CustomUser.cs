using Microsoft.AspNetCore.Identity;

namespace StreamTrace.Models
{
    public class CustomUser: IdentityUser
    {
        public string? Avatar { get; set; }
    }
}
