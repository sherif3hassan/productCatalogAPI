using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductCatalogAPI.Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalogAPI.Identity.Configurations
{
    public class UserConfiguration: IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.HasData(
                new ApplicationUser
                {
                    Id = "1",
                    Name = "Admin",
                    NormalizedUserName = "ADMIN",
                    NormalizedEmail = "ADMIN@LOCALHOST.COM",
                    UserName = "Admin",
                    Email = "admin@localhost.com",
                    PasswordHash = hasher.HashPassword(null, "Admin@123"),
                },
                new ApplicationUser
                {
                    Id = "2",
                    Name = "User",
                    NormalizedUserName = "USER",
                    NormalizedEmail = "USER@LOCALHOST.COM",
                    UserName = "User",
                    Email = "user@localhost.com",
                    PasswordHash = hasher.HashPassword(null, "User@123"),
                }
                );
        }
    }
}
