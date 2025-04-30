using Microsoft.AspNetCore.Identity;

namespace ProductCatalogAPI.Identity.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; } = string.Empty;
    }
}
