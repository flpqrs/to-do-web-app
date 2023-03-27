using ToDoGame.Domain.Base;
using ToDoGame.Domain.Identity;

namespace ToDoGame.Domain.Entities
{
    public class UserProfile : BaseEntity
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public int LevelId { get; set; }
        public long ExperiencePoints { get; set; }
        public Level Level { get; set; }
        public ApplicationUser User { get; set; }
    }
}
