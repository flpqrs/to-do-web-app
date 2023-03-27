using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ToDoGame.Repository.EntityTypeConfiguration
{
    public class IdentityUserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            const string ADMIN_ID = "51c6ac60-8d09-41c5-9c1e-5d9211badf51";
            const string ROLE_ID = "ed318cd3-0a33-4f41-9eaf-311dbfd377cf";

            builder.HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID
            });
        }
    }
}