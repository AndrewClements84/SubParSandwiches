using Microsoft.AspNetCore.Identity;

namespace SubParSandwiches.Entities
{
    public class Role : IdentityRole<int>
    {
        public string Description { get; set; }
    }
}
