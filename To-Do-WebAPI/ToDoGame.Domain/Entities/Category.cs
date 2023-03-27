using ToDoGame.Domain.Base;

namespace ToDoGame.Domain.Entities
{
    public class Category : IntIdEntity
    {
        public string Name { get; set; }
        public int ExperiencePoints { get; set; }
    }
}
