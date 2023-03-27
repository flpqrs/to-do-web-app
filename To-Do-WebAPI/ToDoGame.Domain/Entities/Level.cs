using ToDoGame.Domain.Base;

namespace ToDoGame.Domain.Entities
{
    public class Level : IntIdEntity
    {
        public long ExperienceRangeFrom { get; set; }
        public long ExperienceRangeTo { get; set; }
    }
}
