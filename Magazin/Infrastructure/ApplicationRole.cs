using Microsoft.AspNet.Identity.EntityFramework;

namespace Magazin.Infrastructure
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() { }

        public string Description { get; set; }
    }
}