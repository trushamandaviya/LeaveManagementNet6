using LeaveManagement.Web.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeaveManagement.Web.Configurations.Entities
{
    public class UserSeedConfigurations : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            var hasher = new PasswordHasher<Employee>();

            builder.HasData(
                new Employee
                {
                    Id = "29bfe99f-7b48-4162-8259-c7055793300e",
                    UserName ="admin@localhost.com",
                    NormalizedUserName ="ADMIN@LOCALHOST.COM",
                    Email = "admin@localhost.com",
                    NormalizedEmail = "ADMIN@LOCALHOST.COM",
                    FristName = "System",
                    LastName = "Admin",
                    PasswordHash = hasher.HashPassword(null, "Admin@1"),
                    EmailConfirmed = true
                },
                new Employee
                {
                    Id = "dcecc932-6d1f-4657-a2ca-9daa6fc3a3ae",
                    UserName = "user@localhost.com",
                    NormalizedUserName = "USER@LOCALHOST.COM",
                    Email = "user@localhost.com",
                    NormalizedEmail = "USER@LOCALHOST.COM",
                    FristName = "System",
                    LastName = "User",
                    PasswordHash = hasher.HashPassword(null, "Admin@1"),
                    EmailConfirmed = true
                }
            );
        }
    }
}