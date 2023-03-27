using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoGame.Domain.Identity;

namespace ToDoGame.Repository.EntityTypeConfiguration
{
    public class IdentityRoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            const string ROLE_ID = "ed318cd3-0a33-4f41-9eaf-311dbfd377cf";

            builder.HasData(new IdentityRole
            {
                Id = ROLE_ID,
                Name = UserRole.Admin,
                NormalizedName = UserRole.Admin
            });
        }
    }
}
