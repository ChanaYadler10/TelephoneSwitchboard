using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Repository.View_Models;

namespace Repository.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);

        //    // IdentityUserLogin Configuration
        //    builder.Entity<IdentityUserLogin<string>>(entity =>
        //    {
        //        entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });
        //    });

        //    // IdentityUserRole Configuration
        //    builder.Entity<IdentityUserRole<string>>(entity =>
        //    {
        //        entity.HasKey(e => new { e.UserId, e.RoleId });
        //    });

        //    // IdentityUserToken Configuration
        //    builder.Entity<IdentityUserToken<string>>(entity =>
        //    {
        //        entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });
        //    });

        //    //Configuration for the relationship between ApplicationUser and Customer

        //    //builder.Entity<ApplicationUser>()
        //    //    .HasOne(a => a.Customer)
        //    //    .WithMany(c => c.ApplicationUsers)
        //    //    .HasForeignKey(a => a.CustomerTblId)
        //    //    .HasConstraintName("FK_ApplicationUser_Customer_CustomerId");
        //}
    }
}
