using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PikYak.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        //could add first/last name here
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        //set a table of yaks - list of yaks //Translate Yaks to be stored in the database
        //property - plurarized form of this object
        public DbSet<Like> Likes { get; set; }

        //include a set of yaks - dbset of type yak will tell intity framework to create a table of yaks
        //set a table of yaks - list of yaks //Translate Yaks to be stored in the database
        //property - prularized form of this object
        public DbSet<Yak> Yaks { get; set; }


        //Create the Reports Tables!!!!!! Store thes into database
        public DbSet<Report> Reports { get; set; }

        //created to be able to delete reported yaks

       // public System.Data.Entity.DbSet<PikYak.Models.YakViewModel> YakViewModels { get; set; }

    }
}