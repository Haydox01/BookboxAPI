using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bookbox.Data
{
    public class BookBoxAuthDbContext : IdentityDbContext
    {
        // dev
        public BookBoxAuthDbContext(DbContextOptions<BookBoxAuthDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);
            

            //Hardcoding ID for each role
            var adminRoleId = "ea5c0bfd-689d-4c2d-8842-6a3464cf215d";
            var editorRoleId = "79605fe8-7a4a-4fae-a1e1-d29a0940e5f8";
            var customerSupportRoleId = "2fd054f6-4db7-4b2f-8c17-6e23e798b904";
            var customerRoleId = "e63a7005-04f6-439b-b018-04a8cfd4ce2a";
            var guestRoleId = "dc63d810-9b69-49a0-9ecd-87d25e4f2a32";


            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = adminRoleId,
                    ConcurrencyStamp = adminRoleId,
                    Name = "Admin",
                    NormalizedName = "Admin".ToUpper()

                },
                new IdentityRole
                {

                    Id = editorRoleId,
                    ConcurrencyStamp = editorRoleId,
                    Name = "Editor",
                    NormalizedName = "Editor".ToUpper()

                },
                new IdentityRole
                {

                    Id = customerSupportRoleId,
                    ConcurrencyStamp = customerSupportRoleId,
                    Name = "Customer Support",
                    NormalizedName = "Customer Support".ToUpper()
                },
                new IdentityRole
                {

                    Id = customerRoleId,
                    ConcurrencyStamp = customerRoleId,
                    Name = "Customer",
                    NormalizedName = "Customer".ToUpper()
                },
                new IdentityRole
                {

                    Id = guestRoleId,
                    ConcurrencyStamp = guestRoleId,
                    Name = "Guest",
                    NormalizedName = "Guest".ToUpper()
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);// Seeding data inside DB
        }
    }
}
