using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoGame.Domain.Entities;

namespace ToDoGame.Repository.EntityTypeConfiguration
{
    public class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            builder.HasOne(b => b.User).WithOne(i => i.Profile);
        }
    }
}
