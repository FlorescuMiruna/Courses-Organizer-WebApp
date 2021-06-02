using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using CoursesOrganizerApp.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;


namespace CoursesOrganizerApp.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext,
            CoursesOrganizerApp.Migrations.Configuration>("DefaultConnection"));
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        // public DbSet<Task> Tasks { get; set; }


        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
