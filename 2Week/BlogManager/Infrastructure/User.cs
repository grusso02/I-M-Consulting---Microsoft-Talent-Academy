using Microsoft.AspNetCore.Identity;

namespace Infrastructure
{
    public class User : IdentityUser<int>
    {
        public string name { get; set; }
        public string phone { get; set; }
        public string website { get; set; }
    }
}
