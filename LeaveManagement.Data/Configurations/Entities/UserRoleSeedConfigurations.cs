using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeaveManagement.Data.Configurations.Entities
{
    public class UserRoleSeedConfigurations : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "29bfe79f-7b48-4162-8259-a7055793900e",
                    UserId = "29bfe99f-7b48-4162-8259-c7055793300e"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "dcecc452-6d1f-4657-a2aa-9daa6fc9a3ae",
                    UserId = "dcecc932-6d1f-4657-a2ca-9daa6fc3a3ae"
                }
            );
        }
    }
}