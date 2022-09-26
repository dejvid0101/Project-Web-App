using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Client_Side.Models
{
    public class Role : IdentityRole<int, UserRole>
    {
        public Role() { }
        public Role(string name) { Name = name; }
    }
    public class UserRole : IdentityUserRole<int> { }
    public class UserClaim : IdentityUserClaim<int> { }
    public class UserLogin : IdentityUserLogin<int> { }
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class AppUser : IdentityUser<int,
UserLogin, UserRole, UserClaim>

    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<AppUser,int> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class RwaIdentityDbContext : IdentityDbContext<AppUser, Role,
int, UserLogin, UserRole, UserClaim>

    {
        public RwaIdentityDbContext()
            : base("DefaultConnection")
        {
        }

        public static RwaIdentityDbContext Create()
        {
            return new RwaIdentityDbContext();
        }
    }
}