namespace SmallHotels.Auth.Models
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using SmallHotels.Data.Models;

    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext()
            : base("SmallHotels", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}