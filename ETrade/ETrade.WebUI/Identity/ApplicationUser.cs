using Microsoft.AspNetCore.Identity;

namespace ETrade.WebUI.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}
