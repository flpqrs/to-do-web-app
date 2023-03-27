using Microsoft.AspNetCore.Identity;
using ToDoGame.Domain.Entities;

namespace ToDoGame.Domain.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public UserProfile? Profile { get; set; }
    }
}
