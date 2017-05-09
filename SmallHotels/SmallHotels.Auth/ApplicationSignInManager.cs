namespace SmallHotels.Auth
{
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity.Owin;
    using Microsoft.Owin;
    using Microsoft.Owin.Security;

    using SmallHotels.Auth.Contracts;
    using SmallHotels.Data.Models;

    // Configure the application sign-in manager which is used in this application.
    public class ApplicationSignInManager : SignInManager<User, string>, ISignInService
    {
        public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
        {
            return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
        }

        public override Task<SignInStatus> PasswordSignInAsync(string userName, string password, bool isPersistent, bool shouldLockout)
        {
            var user = this.UserManager.FindByNameAsync(userName).Result;

            if (user.IsDeleted)
            {
                return Task.FromResult(SignInStatus.Failure);
            }

            return base.PasswordSignInAsync(userName, password, isPersistent, shouldLockout);
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(User user)
        {
            return user.GenerateUserIdentityAsync((ApplicationUserManager)UserManager);
        }
    }
}
